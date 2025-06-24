using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TuristicaAt.Data;
using TuristicaAt.Models;

namespace TuristicaAt.Pages.Reserva;

public class VerificarCadastro : PageModel
{
    private readonly ReservaDbContext _context;

    public VerificarCadastro(ReservaDbContext context)
    {
        _context = context;
    }
    
    [BindProperty]
    public string Email { get; set; }
    
    [BindProperty]
    public int Id { get; set; }
    
    
    public void OnGet(int id)
    {
        Id = id;
    }

    public IActionResult OnPost()
    {
        
        try
        {
            var ClienteEncontrado = _context.Clientes.FirstOrDefault(x => x.Email == Email);
            if (ClienteEncontrado != null)
            {
                return RedirectToPage("Create", new { Email = Email, Id = Id });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Nenhum cliente encontrado com o Email informado.");
                return Page();
            }
        }
        catch (Exception e)
        {
            ModelState.AddModelError(string.Empty, "Erro ao acessar os dados. Tente novamente mais tarde.");
            return Page();

        }
       
       
    }
}