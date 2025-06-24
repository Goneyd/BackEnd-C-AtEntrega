using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TuristicaAt.Models;
using TuristicaAt.ServiceMemoria;

namespace TuristicaAt.Pages;

public class IncluirPacotes : PageModel
{
    private IServiceReserva _serviceReserva;
    
    
    [BindProperty]
    public PacoteTuristico NovoPacote { get; set;}
    
    public SelectList Destinos { get; set; }

    public IncluirPacotes(IServiceReserva serviceReserva)
    {
        _serviceReserva = serviceReserva;
    }
    
    public void OnGet()
    {
        Destinos = new SelectList(_serviceReserva.ObterTodosDestinos(),
            nameof(Destino.Id),
            nameof(Destino.Nome));
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        
        _serviceReserva.IncluirPacote(NovoPacote);
        return RedirectToPage("/Index");
    }
}