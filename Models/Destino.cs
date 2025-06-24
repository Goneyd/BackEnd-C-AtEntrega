using System.ComponentModel.DataAnnotations;

namespace TuristicaAt.Models;

public class Destino
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(5, ErrorMessage = "O Nome deve ter no mínimo 5 caracteres")]
    [Display(Name = "Nome: ")]
    public string Nome { get; set; }
    [Display(Name = "Pais: ")]
    [MinLength(4, ErrorMessage = "O Pais deve ter no mínimo 4 caracteres")]
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Pais { get; set; }
}