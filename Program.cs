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
        // Guardamos el host en una variable estática para poder exponer su IServiceProvider
        private static IHost _host;

        [STAThread]
        static void Main()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((_, services) =>
                {
                    // 1) DbContext: alcance "scoped"
                    services.AddDbContext<AppDbContext>(opts =>
                        opts.UseSqlServer(
                            @"Server=(localdb)\MSSQLLocalDB;Database=CabinasDb;Trusted_Connection=True;"
                        ),
                        contextLifetime: ServiceLifetime.Scoped
                    );

                    // 2) Servicios / ViewModels
                    services.AddTransient<ReservaUIService>();
                    services.AddTransient<ReservaViewModel>();
                    services.AddTransient<UsuarioViewModel>();

                    // 3) Formularios
                    services.AddTransient<MainForm>();
                    services.AddTransient<ReservaForm>();
                    services.AddTransient<NuevaReservaForm>();
                    services.AddTransient<NuevoUsuarioForm>();
                    services.AddTransient<MenuUsuariosForm>();
                    services.AddTransient<MenuReservasForm>();
                })
                .Build();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Creamos un scope para resolver MainForm y ejecutarla
            using (var scope = _host.Services.CreateScope())
            {
                var mainForm = scope.ServiceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        /// <summary>
        /// Permite acceder al IServiceProvider global (root) para resolver servicios/formularios
        /// desde cualquier parte de la aplicación.
        /// </summary>
        public static IServiceProvider GetServiceProvider()
        {
            return _host.Services;
        }
    }
}
