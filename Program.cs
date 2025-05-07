using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reserva_de_Espacios_Biblioteca.Data;
using Reserva_de_Espacios_Biblioteca.Services;
using Reserva_de_Espacios_Biblioteca.ViewModels;
using Reserva_de_Espacios_Biblioteca.Views;

namespace Reserva_de_Espacios_Biblioteca
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    // 1) DbContext transient: nueva instancia en cada inyección
                    services.AddDbContext<AppDbContext>(opts =>
                        opts.UseSqlServer(
                          @"Server=(localdb)\MSSQLLocalDB;Database=CabinasDb;Trusted_Connection=True;",
                          sqlOpts => { /* opcional: timeouts, etc. */ }
                        ),
                        contextLifetime: ServiceLifetime.Transient
                    );


                    // 2) Registrar Services y ViewModels (todos transient)
                    services.AddTransient<ReservaUiService>();
                    services.AddTransient<MainViewModel>();
                    services.AddTransient<ReservaViewModel>();

                    // 3) Formularios
                    services.AddTransient<MainForm>();
                    services.AddTransient<ReservaForm>();
                    services.AddTransient<NuevaReservaForm>();
                })
                .Build();


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Resolvemos MainForm e iniciamos la aplicación
            var mainForm = host.Services.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }
    }
}
