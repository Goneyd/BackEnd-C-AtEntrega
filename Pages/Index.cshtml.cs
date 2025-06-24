using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuristicaAt.Data;
using TuristicaAt.Models;
using TuristicaAt.ServiceMemoria;

namespace TuristicaAt.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private IServiceReserva _serviceReserva;
    public IList<PacoteTuristico> _pacotesTuristicos;
    

    public IndexModel(ILogger<IndexModel> logger,IServiceReserva serviceReserva)
    {
        _logger = logger;
        _serviceReserva = serviceReserva;
    }

    public void OnGet()
    {
     _pacotesTuristicos = _serviceReserva.ObterTodosPacotes();
    }
}
