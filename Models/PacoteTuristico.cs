using System.ComponentModel.DataAnnotations;

namespace TuristicaAt.Models;

public class PacoteTuristico
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [MinLength(5, ErrorMessage = "O título deve ter no mínimo 5 caracteres")]
    [Display(Name = "Titulo:")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [Range(1,double.MaxValue,ErrorMessage = "O preço deve ser maior que 0")]
    [Display(Name = "Preço:")]
    [DataType(DataType.Currency)]
    public decimal Preco { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Data de Inicio:")]
    public DateTime DataDeInicio { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public int DestinoId { get; set; }
    public Destino? Destino { get; set; }
    
}