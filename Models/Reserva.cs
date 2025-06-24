using System.ComponentModel.DataAnnotations;

namespace TuristicaAt.Models;

public class Reserva
{
    public int Id { get; set;}
    [Required(ErrorMessage = "Campo obrigatório")]
    [Display(Name = "Quantidade de Pessoas:")]
    public int QuantidaDePessoas { get; set; }
    public decimal? PrecoTotal { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public DateTime DataDeReserva { get; set; }
    [Required(ErrorMessage = "Campo obrigatório")]
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set;}
    [Required(ErrorMessage = "Campo obrigatório")]
    public int PacoteTuristicoId { get; set; }
    public PacoteTuristico? PacoteTuristico { get; set; }
    
}