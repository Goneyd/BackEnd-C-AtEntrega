using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuristicaAt.Data;
using TuristicaAt.Models;
using TuristicaAt.ServiceMemoria;

namespace TuristicaAt.Pages.Reserva;

public class Create : PageModel
{
    private readonly ReservaDbContext _context;
    private IServiceReserva _serviceReserva;
    
    [BindProperty]
    public Models.Reserva NovaReserva { get; set; }
    [BindProperty(SupportsGet = true)]
    public string Email { get; set; }
    
    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }
    
    public Cliente ClienteEncontrado { get; set; }
    public PacoteTuristico PacoteTuristicoEncontrado { get; set; }
    public Destino DestinoEncontrado { get; set; }
    public decimal PrecoTotal { get; set; }
    
    public Create(IServiceReserva serviceReserva,ReservaDbContext context)
    {
        _serviceReserva = serviceReserva;
        _context = context;
    }
    
    public void OnGet()
    {
        PacoteTuristicoEncontrado = _serviceReserva.ObterPacote(Id);
        DestinoEncontrado = _serviceReserva.ObterDestino(PacoteTuristicoEncontrado.DestinoId);
        ClienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == Email);
        
        NovaReserva = new Models.Reserva
        {
            DataDeReserva = DateTime.Now.Date,
            ClienteId = ClienteEncontrado.Id,
            PacoteTuristicoId = PacoteTuristicoEncontrado.Id,
        };
    }

    public IActionResult OnPost(int id)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        PacoteTuristicoEncontrado = _serviceReserva.ObterPacote(id);
        PrecoTotal = PacoteTuristicoEncontrado.Preco * NovaReserva.QuantidaDePessoas;
        NovaReserva.PrecoTotal = PrecoTotal;
        _context.Reservas.Add(NovaReserva);
        _context.SaveChanges();
        
        return RedirectToPage("/Pages/Index");

    }

}
