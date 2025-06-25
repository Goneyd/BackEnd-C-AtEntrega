using TuristicaAt.Data;
using TuristicaAt.ServiceMemoria;
using ServiceReserva = TuristicaAt.ServiceMemoria.DataBase.ServiceReserva;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace TuristicaAt;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // var connectionString = builder.Configuration.GetConnectionString("ReservaDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ReservaDbContextConnection' not found.");

        builder.Services.AddRazorPages();

        builder.Services.AddTransient<IServiceReserva, ServiceReserva>();
        builder.Services.AddDbContext<ReservaDbContext>();

        builder.Services.
            AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ReservaDbContext>();
        
        builder.Services.Configure<IdentityOptions>(options => {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredLength = 3;
// Lockout settings
            options.Lockout.MaxFailedAccessAttempts = 30;
            options.Lockout.AllowedForNewUsers = true;
// User settings
            options.User.RequireUniqueEmail = true;
        });
        builder.Services.AddRazorPages(options => {
            options.Conventions.AuthorizeFolder("/Reserva");
            options.Conventions.AuthorizeFolder("/Destinos");
            options.Conventions.AuthorizeFolder("/Clientes");
        });
        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
             app.UseHsts();
        }
        

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}
