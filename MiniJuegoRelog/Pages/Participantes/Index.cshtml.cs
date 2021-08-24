using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using MiniJuegoRelog.Data;
using MiniJuegoRelog.Interfaces;
using MiniJuegoRelog.Modelos;
using MiniJuegoRelog.Services;

namespace MiniJuegoRelog.Pages.Participantes
{
    public class IndexModel : PageModel
    {
        private readonly IParticipanteRepositoryAsync _participante;
        private readonly IRazorRenderService _renderService;

        public IndexModel(IParticipanteRepositoryAsync participante, IRazorRenderService renderService)
        {
            this._participante = participante;
            this._renderService = renderService;
        }

        public IEnumerable<Participante> Participantes { get; set; }

        public async Task OnGet()
        {
            //this.Participantes = await _context.PARTICIPANTES.ToListAsync();

        }
        public async Task<PartialViewResult> OnGetViewAllPartial()
        {
            this.Participantes = await this._participante.GetAllAsync();
            return new PartialViewResult
            {
                ViewName = "_ViewAll",
                ViewData = new ViewDataDictionary<IEnumerable<Participante>>(ViewData, this.Participantes)
            };
        }
        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            if (id == 0)
            {
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", new Participante()) });
            }
            else
            {
                var thisEmployee = await this._participante.GetByIdAsync(id);
                return new JsonResult(new { isValid = true, html = await _renderService.ToStringAsync("_CreateOrEdit", thisEmployee) });
            }
           
        }
    }
}
