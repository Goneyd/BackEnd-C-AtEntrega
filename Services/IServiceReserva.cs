using TuristicaAt.Models;

namespace TuristicaAt.ServiceMemoria;

public interface IServiceReserva
{
    public IList<PacoteTuristico> ObterTodosPacotes();
    public IList<Destino> ObterTodosDestinos();
    public void IncluirPacote(PacoteTuristico pacote);
    public PacoteTuristico ObterPacote(int id);
    public Destino ObterDestino(int id);
    public void AlterarPacote(PacoteTuristico pacote);
    public void ExcluirPacote(int Id);
    public void IncluirReserva(Reserva reserva);
}