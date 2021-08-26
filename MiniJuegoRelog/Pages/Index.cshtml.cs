using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MiniJuegoRelog.Data;
using MiniJuegoRelog.Interfaces;
using MiniJuegoRelog.Modelos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace MiniJuegoRelog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITiemposRepositoryAsync _tiempo;
        private readonly IParticipanteRepositoryAsync _participante;
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<Tiempos> Tiempos { get; set; }
        public IEnumerable<Participante> Participantes { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ITiemposRepositoryAsync tiempo, IParticipanteRepositoryAsync participante)
        {
            this._logger = logger;
            this._tiempo = tiempo;
            this._participante = participante;
        }

        public void OnGet()
        {
        }

        public async Task<PartialViewResult> OnGetViewAll2Partial()
        {
            this.Tiempos = await this._tiempo.GetAllAsync();
            this.Participantes = await this._participante.GetAllAsync();

            foreach (Tiempos tiempo in this.Tiempos)
            {
                tiempo.Participante = this.Participantes.Single(p => p.Id == tiempo.ParticipanteId);
            }

            return new PartialViewResult
            {
                ViewName = "_ViewAll2",
                ViewData = new ViewDataDictionary<IEnumerable<Tiempos>>(ViewData, this.Tiempos)
            };
        }

    }
}
