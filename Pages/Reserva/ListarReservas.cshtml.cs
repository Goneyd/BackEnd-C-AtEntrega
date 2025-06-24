using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TuristicaAt.Data;
using TuristicaAt.Models;
using System.Collections.Generic;

namespace TuristicaAt.Pages.Reserva
{
    public class ListarReservas : PageModel
    {
        private readonly ReservaDbContext _context;

        public IList<Models.Reserva> Reservas { get; set; } = new List<Models.Reserva>();

        public ListarReservas(ReservaDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Reservas = _context.Reservas
                .Include(reserva => reserva.Cliente)
                .Include(reserva => reserva.PacoteTuristico)
                .ThenInclude(pacote => pacote.Destino)
                .ToList();
        }
    }
}