using Microsoft.EntityFrameworkCore;
using Reserva_de_Espacios_Biblioteca.Data.Entities;

namespace Reserva_de_Espacios_Biblioteca.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options) { }

        public DbSet<Cabina> Cabinas { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;
    }
}
