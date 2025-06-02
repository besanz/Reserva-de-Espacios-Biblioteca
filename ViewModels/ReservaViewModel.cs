#nullable disable
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
        public ObservableCollection<Usuario> Usuarios { get; } = new();

        public ReservaViewModel(AppDbContext db) => _db = db;

        /// <summary>
        /// Carga listas de cabinas y reservas (para el diálogo si hiciera falta).
        /// </summary>
        public async Task CargarDatosAsync()
        {
            Cabinas.Clear();
            var listaCabinas = await _db.Cabinas.OrderBy(ca => ca.Id).ToListAsync();
            foreach (var c in listaCabinas)
                Cabinas.Add(c);

            Reservas.Clear();
            var listaReservas = await _db.Reservas.ToListAsync();
            foreach (var r in listaReservas)
                Reservas.Add(r);
        }

        /// <summary>
        /// Construye la tabla de horario para el día dado.
        /// </summary>
        public async Task<DataTable> GetScheduleTableAsync(DateTime date)
        {
            var cabinas = await _db.Cabinas.OrderBy(c => c.Id).ToListAsync();
            var reservas = await _db.Reservas
                .Where(r => r.Inicio.Date == date.Date)
                .ToListAsync();

            var usuarioIdsDelDia = reservas.Select(r => r.UsuarioId).Distinct().ToList();
            var usuarios = await _db.Usuarios
                .Where(u => usuarioIdsDelDia.Contains(u.Id))
                .ToListAsync();

            var table = new DataTable();
            table.Columns.Add("Hora");
            foreach (var c in cabinas)
                table.Columns.Add(c.Nombre);

            var start = date.Date.AddHours(8);
            var end = date.Date.AddHours(20);
            for (var slot = start; slot < end; slot = slot.AddMinutes(15))
            {
                var row = table.NewRow();
                row["Hora"] = slot.ToString("HH:mm");

                foreach (var c in cabinas)
                {
                    var r = reservas.FirstOrDefault(x =>
                        x.CabinaId == c.Id &&
                        x.Inicio <= slot &&
                        x.Fin > slot);
                    if (r != null)
                    {
                        var u = usuarios.FirstOrDefault(x => x.Id == r.UsuarioId);
                        if (u != null)
                        {
                            var durHoras = (r.Fin - r.Inicio).TotalHours;
                            row[c.Nombre] = $"{u.Apellidos} {u.Nombre} ({durHoras:N1}h)";
                        }
                        else
                        {
                            var durHoras = (r.Fin - r.Inicio).TotalHours;
                            row[c.Nombre] = $"(UsuarioId {r.UsuarioId}) ({durHoras:N1}h)";
                        }
                    }
                    else
                    {
                        row[c.Nombre] = string.Empty;
                    }
                }

                table.Rows.Add(row);
            }

            return table;
        }

        /// <summary>
        /// Crea una reserva. Devuelve true si no hay conflicto de horario.
        /// </summary>
        public async Task<bool> CreateReservaAsync(Reserva r)
        {
            bool conflicto = await _db.Reservas.AnyAsync(x =>
                x.CabinaId == r.CabinaId &&
                x.Inicio < r.Fin &&
                x.Fin > r.Inicio);
            if (conflicto) return false;

            _db.Reservas.Add(r);
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Actualiza una reserva existente. Devuelve true si no hay conflicto.
        /// </summary>
        public async Task<bool> UpdateReservaAsync(Reserva r)
        {
            bool conflicto = await _db.Reservas.AnyAsync(x =>
                x.Id != r.Id &&
                x.CabinaId == r.CabinaId &&
                x.Inicio < r.Fin &&
                x.Fin > r.Inicio);
            if (conflicto) return false;

            _db.Reservas.Update(r);
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Elimina la reserva con el id dado. Devuelve true si existía.
        /// </summary>
        public async Task<bool> DeleteReservaAsync(int id)
        {
            var entidad = await _db.Reservas.FindAsync(id);
            if (entidad == null) return false;

            _db.Reservas.Remove(entidad);
            await _db.SaveChangesAsync();
            return true;
        }

        // ──────────────────────────────────────────────────────────────
        // MÉTODOS RELACIONADOS CON USUARIOS
        // ──────────────────────────────────────────────────────────────

        /// <summary>
        /// Busca usuarios activos. Si filtro es vacío, devuelve todos los usuarios activos.
        /// </summary>
        public async Task<ObservableCollection<Usuario>> BuscarUsuariosAsync(string filtro)
        {
            // Si no hay filtro, devolvemos todos los que estén activos
            if (string.IsNullOrWhiteSpace(filtro))
            {
                var todosActivos = await _db.Usuarios
                    .Where(u => u.EstaActivo)
                    .OrderBy(u => u.Apellidos)
                    .ThenBy(u => u.Nombre)
                    .ToListAsync();
                return new ObservableCollection<Usuario>(todosActivos);
            }

            filtro = filtro.Trim();
            var lista = await _db.Usuarios
                .Where(u => u.EstaActivo &&
                            (u.Dni == filtro ||
                             EF.Functions.Like(u.Nombre + " " + u.Apellidos, $"%{filtro}%") ||
                             EF.Functions.Like(u.Apellidos + " " + u.Nombre, $"%{filtro}%")))
                .OrderBy(u => u.Apellidos)
                .ThenBy(u => u.Nombre)
                .ToListAsync();

            return new ObservableCollection<Usuario>(lista);
        }

        /// <summary>
        /// Recupera un Usuario por su Id (o null si no existe).
        /// </summary>
        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Crea un nuevo usuario. Devuelve false si el DNI ya estaba en uso.
        /// </summary>
        public async Task<bool> CreateUsuarioAsync(Usuario u)
        {
            bool existe = await _db.Usuarios.AnyAsync(x => x.Dni == u.Dni);
            if (existe) return false;

            u.FechaRegistro = DateTime.Now;
            _db.Usuarios.Add(u);
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un usuario existente. Devuelve false si el DNI choca con otro usuario.
        /// </summary>
        public async Task<bool> UpdateUsuarioAsync(Usuario u)
        {
            var existente = await _db.Usuarios.FirstOrDefaultAsync(x => x.Id == u.Id);
            if (existente == null) return false;

            bool conflictoDni = await _db.Usuarios.AnyAsync(x => x.Dni == u.Dni && x.Id != u.Id);
            if (conflictoDni) return false;

            existente.Dni = u.Dni;
            existente.Nombre = u.Nombre;
            existente.Apellidos = u.Apellidos;
            existente.Email = u.Email;
            existente.Telefono = u.Telefono;
            existente.EstaActivo = u.EstaActivo;
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Activa o desactiva un usuario. Devuelve false si no existe.
        /// </summary>
        public async Task<bool> ToggleActivoUsuarioAsync(int usuarioId, bool nuevoEstado)
        {
            var u = await _db.Usuarios.FirstOrDefaultAsync(x => x.Id == usuarioId);
            if (u == null) return false;

            u.EstaActivo = nuevoEstado;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
