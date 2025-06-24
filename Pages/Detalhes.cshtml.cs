using Microsoft.AspNetCore.Mvc.RazorPages;
using TuristicaAt.Models;
using TuristicaAt.ServiceMemoria;

namespace TuristicaAt.Pages;

public class Detalhes : PageModel
{
    public PacoteTuristico PacoteTuristico { get; set; }
    public Destino Destino { get; set; }

    private IServiceReserva _service;

    public Detalhes( IServiceReserva serviceReserva)
    {
        _service = serviceReserva;
    }

    public void OnGet(int id)
    {
        PacoteTuristico = _service.ObterPacote(id);
        Destino = _service.ObterDestino(PacoteTuristico.DestinoId);
    }
}