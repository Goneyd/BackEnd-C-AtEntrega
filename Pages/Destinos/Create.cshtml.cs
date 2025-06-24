using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TuristicaAt.Data;
using TuristicaAt.Models;

namespace TuristicaAt.Pages.Destinos
{
    public class CreateModel : PageModel
    {
        private readonly TuristicaAt.Data.ReservaDbContext _context;

        public CreateModel(TuristicaAt.Data.ReservaDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Destino Destino { get; set; } = default!;

  
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Destinos.Add(Destino);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
