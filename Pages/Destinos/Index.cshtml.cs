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
    public class IndexModel : PageModel
    {
        private readonly TuristicaAt.Data.ReservaDbContext _context;

        public IndexModel(TuristicaAt.Data.ReservaDbContext context)
        {
            _context = context;
        }

        public IList<Destino> Destino { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Destino = await _context.Destinos.ToListAsync();
        }
    }
}
