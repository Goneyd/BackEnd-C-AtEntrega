using TuristicaAt.Data;
using TuristicaAt.ServiceMemoria;
using ServiceReserva = TuristicaAt.ServiceMemoria.DataBase.ServiceReserva;

namespace TuristicaAt;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services.AddTransient<IServiceReserva, ServiceReserva>();
        builder.Services.AddDbContext<ReservaDbContext>();
        
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
             app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}
