using Microsoft.EntityFrameworkCore;
using TuristicaAt.Models;

namespace TuristicaAt.Data;

public class ReservaDbContext : DbContext
{
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Destino> Destinos { get; set; }
    public DbSet<PacoteTuristico> PacoteTuristicos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    
    protected override void OnConfiguring
    (
        DbContextOptionsBuilder optionsBuilder
    )
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        string conn = config.GetConnectionString("MyConn");
        optionsBuilder.UseSqlServer(conn);
    }
}