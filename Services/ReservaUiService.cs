using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reserva_de_Espacios_Biblioteca.Data;
using Reserva_de_Espacios_Biblioteca.Data.Entities;

namespace Reserva_de_Espacios_Biblioteca.Services
{
    public class ReservaUiService
    {
        private readonly AppDbContext _db;
        public ReservaUiService(AppDbContext db) => _db = db;

        public Task<List<Cabina>> GetCabinasAsync()
          => _db.Cabinas.ToListAsync();

        public Task<List<Reserva>> GetReservasAsync()
          => _db.Reservas.ToListAsync();

        public Task CreateReservaAsync(Reserva r)
        {
            _db.Reservas.Add(r);
            return _db.SaveChangesAsync();
        }
    }
}
