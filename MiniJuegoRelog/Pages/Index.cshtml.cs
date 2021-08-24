using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string Tiempo { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public async Task<JsonResult> OnGetCreateOrEditAsync(int id = 0)
        {
            return new JsonResult(new { isValid = true, html = "" });
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                this.Tiempo = this.Tiempo;
                return Page();
            }
            else
            {
                return Page();
            }
        }
    }
}
