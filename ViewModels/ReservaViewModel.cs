using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Reserva_de_Espacios_Biblioteca.Data;
using Reserva_de_Espacios_Biblioteca.Data.Entities;

namespace Reserva_de_Espacios_Biblioteca.ViewModels
{
    public partial class ReservaViewModel : ObservableObject
    {
        private readonly AppDbContext _db;
        public ObservableCollection<Cabina> Cabinas { get; } = new();
        public ObservableCollection<Reserva> Reservas { get; } = new();

        public ReservaViewModel(AppDbContext db) => _db = db;

        /// <summary>Carga listas de cabinas y reservas (para el diálogo si hiciera falta).</summary>
        public async Task CargarDatosAsync()
        {
            Cabinas.Clear();
            foreach (var c in await _db.Cabinas.OrderBy(ca => ca.Id).ToListAsync())
                Cabinas.Add(c);

            Reservas.Clear();
            foreach (var r in await _db.Reservas.ToListAsync())
                Reservas.Add(r);
        }

        /// <summary>Construye la tabla de horario para el día dado.</summary>
        public async Task<DataTable> GetScheduleTableAsync(DateTime date)
        {
            // 1) Cargo cabinas y reservas del día
            var cabinas = await _db.Cabinas.OrderBy(c => c.Id).ToListAsync();
            var reservas = await _db.Reservas
              .Where(r => r.Inicio.Date == date.Date)
              .ToListAsync();

            // 2) Creo la tabla con primera columna "Hora" y luego una por cabina
            var table = new DataTable();
            table.Columns.Add("Hora");
            foreach (var c in cabinas)
                table.Columns.Add(c.Nombre);

            // 3) Recorro desde las 8:00 hasta las 20:00 en pasos de 15 minutos
            var start = date.Date.AddHours(8);
            var end = date.Date.AddHours(20);
            for (var slot = start; slot < end; slot = slot.AddMinutes(15))
            {
                var row = table.NewRow();
                row["Hora"] = slot.ToString("HH:mm");

                foreach (var c in cabinas)
                {
                    // Busco si hay reserva que cubra ESTE slot
                    var r = reservas.FirstOrDefault(x =>
                      x.CabinaId == c.Id &&
                      x.Inicio <= slot &&
                      x.Fin > slot);
                    row[c.Nombre] = r != null
                      ? $"{r.SocioDni} ({(r.Fin - r.Inicio).TotalHours:N1}h)"
                      : string.Empty;
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public Task CreateReservaAsync(Reserva r)
        {
            _db.Reservas.Add(r);
            return _db.SaveChangesAsync();
        }
    }
}
