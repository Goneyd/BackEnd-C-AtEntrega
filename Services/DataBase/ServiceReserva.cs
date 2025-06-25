using TuristicaAt.Data;
using TuristicaAt.Models;

namespace TuristicaAt.ServiceMemoria.DataBase;

public class ServiceReserva : IServiceReserva
{
    private ReservaDbContext _context;
    private ILogger<ServiceReserva> _logger;

    public ServiceReserva(ReservaDbContext context,ILogger<ServiceReserva> logger)
    {
        _context = context;
        _logger = logger;
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
    
    public delegate decimal DescontoDeAcordoComIdade(DateOnly dataDeNascimento, decimal preco);

    public decimal DescontoDeAcordoComIdadeFunc(DateOnly dataDeNascimento, decimal preco)
    {
        DateTime hoje = DateTime.Now;
        int idade = hoje.Year - dataDeNascimento.Year;
        if (hoje.Month < dataDeNascimento.Month || (hoje.Month == dataDeNascimento.Month && hoje.Day < dataDeNascimento.Day))
        {
            idade = idade - 1;
        }

        if (idade >= 65)
        {
            decimal valorComDesconto = preco * 0.8m;
            return valorComDesconto;
        }
        else
        {
            return preco;
        }
    }

    public void LogPrecoTotal(Reserva reserva)
    {
        _logger.LogInformation($"Preço total da reserva: {reserva.PrecoTotal}");
    }
    
    public void LogClienteId(Reserva reserva)
    {
        _logger.LogInformation($"Preço total da reserva: {reserva.ClienteId}");
    }
    
    public void LogPacoteTuristicoId(Reserva reserva)
    {
        _logger.LogInformation($"Preço total da reserva: {reserva.PacoteTuristicoId}");
    }
    
    public delegate void LimiteDeViajantesAtingido(Reserva reserva);

    public event LimiteDeViajantesAtingido? LimiteAtingidoEvent;

    public void LimiteDeViajantesFunc(Reserva reserva)
    {
        _logger.LogInformation($"Limite de viajantes atingido: {reserva.QuantidaDePessoas}, Oferecer ao cliente um serviço de transfer.");
    }
    
    public void IncluirReserva(Reserva reserva)
    {
        DescontoDeAcordoComIdade desconto = DescontoDeAcordoComIdadeFunc;
        PacoteTuristico pacote = ObterPacote(reserva.PacoteTuristicoId);
        Cliente cliente = _context.Clientes.Find(reserva.ClienteId);
        decimal ValorPacoteComDesconto = desconto(cliente.DataDeNascimento, pacote.Preco);
        
        
        Func<Reserva,decimal,decimal> ValorTotal = (Reserva r, decimal vp) => r.QuantidaDePessoas * vp;
        reserva.PrecoTotal = ValorTotal(reserva, ValorPacoteComDesconto);
        
        Action<Reserva> logPrecoTotalClienteIdPacoteId;
        logPrecoTotalClienteIdPacoteId = LogPrecoTotal;
        logPrecoTotalClienteIdPacoteId += LogClienteId;
        logPrecoTotalClienteIdPacoteId += LogPacoteTuristicoId;
        logPrecoTotalClienteIdPacoteId(reserva);

        LimiteAtingidoEvent += LimiteDeViajantesFunc;

        if (reserva.QuantidaDePessoas > 10)
        {
            LimiteAtingidoEvent?.Invoke(reserva);
        }
        
        _context.Reservas.Add(reserva);
        _context.SaveChanges();
    }

}