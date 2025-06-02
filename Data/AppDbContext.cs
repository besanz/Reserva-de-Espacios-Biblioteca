using Microsoft.EntityFrameworkCore;
using Reserva_de_Espacios_Biblioteca.Data.Entities;

namespace Reserva_de_Espacios_Biblioteca.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cabina> Cabinas { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -------------------------------------------------------------
            //   2.1. Sembrar datos de Cabinas, Usuarios y Reservas
            // -------------------------------------------------------------
            //
            //   Aquí indicamos a EF Core que genere los datos iniciales
            //   para Cabinas y Usuarios, y luego varias Reservas para los
            //   días 2, 3, 4, 5, 6 de junio de 2025 (10:00–15:00).
            //
            //   Ajusta los ID’s si cambias algo en tu modelo.
            //

            // a) Sembrar las dos Cabinas: (Id=1: Cabina Individual, Id=2: Cabina Grupal)
            modelBuilder.Entity<Cabina>().HasData(
                new Cabina { Id = 1, Nombre = "Cabina Individual", Capacidad = 1 },
                new Cabina { Id = 2, Nombre = "Cabina Grupal", Capacidad = 4 }
            );

            // b) Sembrar dos Usuarios de ejemplo (Id=1 y Id=2)
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    Dni = "12345678A",
                    Nombre = "Juan",
                    Apellidos = "Pérez García",
                    Email = "juan.perez@ejemplo.com",
                    Telefono = "612345678",
                    EstaActivo = true,
                    FechaRegistro = new DateTime(2025, 1, 1) // fecha arbitraria
                },
                new Usuario
                {
                    Id = 2,
                    Dni = "87654321B",
                    Nombre = "María",
                    Apellidos = "López Sánchez",
                    Email = "maria.lopez@ejemplo.com",
                    Telefono = "687654321",
                    EstaActivo = true,
                    FechaRegistro = new DateTime(2025, 1, 1)
                }
            );

            // c) Sembrar Reservas para los días 2, 3, 4, 5 y 6 de junio de 2025,
            //    cada día dos reservas: una en cabina individual (usuario1) y
            //    otra en cabina grupal (usuario2), ambas de 10:00 a 15:00.
            //
            //    Le damos Id’s consecutivos para las reservas, p.ej. 1..10.
            //
            int reservaId = 1;
            for (int dia = 2; dia <= 6; dia++)
            {
                // Reserva para Cabina Individual (Usuario 1)
                modelBuilder.Entity<Reserva>().HasData(new Reserva
                {
                    Id = reservaId++,
                    CabinaId = 1, // Cabina Individual
                    UsuarioId = 1, // Usuario “Juan”
                    Inicio = new DateTime(2025, 6, dia, 10, 0, 0),
                    Fin = new DateTime(2025, 6, dia, 15, 0, 0)
                });

                // Reserva para Cabina Grupal (Usuario 2)
                modelBuilder.Entity<Reserva>().HasData(new Reserva
                {
                    Id = reservaId++,
                    CabinaId = 2, // Cabina Grupal
                    UsuarioId = 2, // Usuario “María”
                    Inicio = new DateTime(2025, 6, dia, 10, 0, 0),
                    Fin = new DateTime(2025, 6, dia, 15, 0, 0)
                });
            }
        }
    }
}
