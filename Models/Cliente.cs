using System.ComponentModel.DataAnnotations;

namespace TuristicaAt.Models;

public class Cliente
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Data de Nascimento:")]
    public DateOnly DataDeNascimento { get; set; }
    public ICollection<Reserva>? Reservas { get; set; }
}