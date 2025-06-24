using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuristicaAt.Data;
using TuristicaAt.Models;

namespace TuristicaAt.Pages.Destinos
{
    public class DetailsModel : PageModel
    {
        private readonly TuristicaAt.Data.ReservaDbContext _context;

        public DetailsModel(TuristicaAt.Data.ReservaDbContext context)
        {
            _context = context;
        }

        public Destino Destino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.Destinos.FirstOrDefaultAsync(m => m.Id == id);

            if (destino is not null)
            {
                Destino = destino;

                return Page();
            }

            return NotFound();
        }
    }
}
