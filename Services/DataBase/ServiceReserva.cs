using TuristicaAt.Data;
using TuristicaAt.Models;

namespace TuristicaAt.ServiceMemoria.DataBase;

public class ServiceReserva : IServiceReserva
{
    private ReservaDbContext _context;

    public ServiceReserva(ReservaDbContext context)
    {
        _context = context;
    }
    public IList<PacoteTuristico> ObterTodosPacotes()
    {
        return _context.PacoteTuristicos.ToList();
    }
    
    public IList<Destino> ObterTodosDestinos()
    {
        return _context.Destinos.ToList();
    }
    
    public void IncluirPacote(PacoteTuristico pacote )
    {
        _context.PacoteTuristicos.Add(pacote);
        _context.SaveChanges();
    }
    
    
    public PacoteTuristico ObterPacote(int id)
    {
        return _context.PacoteTuristicos.Find(id);
    }
    public Destino ObterDestino(int id)
    {
        return _context.Destinos.Find(id);
    }
    
    public void AlterarPacote(PacoteTuristico pacote)
    {
        var PacoteEncontrado = ObterPacote(pacote.Id);
        PacoteEncontrado.Titulo = pacote.Titulo;
        PacoteEncontrado.DataDeInicio  = pacote.DataDeInicio;
        PacoteEncontrado.Preco  = pacote.Preco;
        PacoteEncontrado.DestinoId  = pacote.DestinoId;
        _context.SaveChanges();
    }
    
    public void ExcluirPacote(int Id)
    {
        var PacoteAchado = ObterPacote(Id);
        _context.PacoteTuristicos.Remove(PacoteAchado);
        _context.SaveChanges();
    }

}