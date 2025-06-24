using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TuristicaAt.Models;
using TuristicaAt.ServiceMemoria;

namespace TuristicaAt.Pages;

public class Edit : PageModel
{
    private IServiceReserva _service;
    
    public SelectList Destinos { get; set; }

    [BindProperty]
    public PacoteTuristico PacoteTuristico { get; set; }
    
    public Edit( IServiceReserva serviceReserva)
    {
        _service = serviceReserva;
    }
    
    public void OnGet(int id)
    {
        PacoteTuristico = _service.ObterPacote(id);
        
        Destinos = new SelectList(_service.ObterTodosDestinos(),
            nameof(Destino.Id),
            nameof(Destino.Nome));
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        _service.AlterarPacote(PacoteTuristico);
        
        return RedirectToPage("/Index");
    }

    public IActionResult OnPostDelete()
    {
        _service.ExcluirPacote(PacoteTuristico.Id);
        return RedirectToPage("/Index");
    }
}