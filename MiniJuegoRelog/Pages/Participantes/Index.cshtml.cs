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
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IParticipanteRepositoryAsync participante, IRazorRenderService renderService, IUnitOfWork unitOfWork)
        {
            this._participante = participante;
            this._renderService = renderService;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Participante> Participantes { get; set; }

        public async void OnGet()
        {
            //this.Participantes = await this._participante.GetAllAsync();

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
        public async Task<JsonResult> OnPostCreateOrEditAsync(int id, Participante participante)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    await _participante.AddAsync(participante);
                    await _unitOfWork.Commit();
                }
                else
                {
                    await _participante.UpdateAsync(participante);
                    await _unitOfWork.Commit();
                }
                this.Participantes = await _participante.GetAllAsync();
                var html = await _renderService.ToStringAsync("_ViewAll", this.Participantes);
                return new JsonResult(new { isValid = true, html = html });
            }
            else
            {
                var html = await _renderService.ToStringAsync("_CreateOrEdit", participante);
                return new JsonResult(new { isValid = false, html = html });
            }
        }
        public async Task<JsonResult> OnPostDeleteAsync(int id)
        {
            var participante = await this._participante.GetByIdAsync(id);
            await this._participante.DeleteAsync(participante);
            await this._unitOfWork.Commit();
            this.Participantes = await _participante.GetAllAsync();
            var html = await _renderService.ToStringAsync("_ViewAll", this.Participantes);
            return new JsonResult(new { isValid = true, html = html });
        }
    }
}
