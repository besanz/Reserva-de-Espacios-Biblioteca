using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Reserva_de_Espacios_Biblioteca.Data;
using Reserva_de_Espacios_Biblioteca.Data.Entities;

namespace Reserva_de_Espacios_Biblioteca.ViewModels
{
    public partial class UsuarioViewModel : ObservableObject
    {
        private readonly AppDbContext _db;

        public UsuarioViewModel(AppDbContext db)
        {
            _db = db;
        }

        // —————————————————————————————————————————————————————————————————————————
        // Propiedades observables para enlazar con la UI si fuera necesario
        // —————————————————————————————————————————————————————————————————————————

        [ObservableProperty]
        private string titulo = "Reserva de Espacios - Biblioteca Municipal";

        // Lista de usuarios en memoria (por ejemplo para enlazar a un DataGridView).
        public ObservableCollection<Usuario> Usuarios { get; } = new();

        // —————————————————————————————————————————————————————————————————————————
        // MÉTODOS ASÍNCRONOS PARA CRUD DE USUARIOS
        // —————————————————————————————————————————————————————————————————————————

        /// <summary>
        /// Carga todos los usuarios (o recarga la colección).
        /// </summary>
        public async Task CargarTodosAsync()
        {
            Usuarios.Clear();
            var lista = await _db.Usuarios
                .OrderBy(u => u.Apellidos)
                .ThenBy(u => u.Nombre)
                .ToListAsync();
            foreach (var u in lista)
            {
                Usuarios.Add(u);
            }
        }

        /// <summary>
        /// Busca usuarios cuyo DNI coincide exactamente con el filtro
        /// o cuyo "Nombre Apellidos" contenga el filtro (o viceversa).
        /// Retorna solo los que estén activos (EstaActivo == true).
        /// </summary>
        public async Task<ObservableCollection<Usuario>> BuscarUsuariosAsync(string filtro)
        {
            if (string.IsNullOrWhiteSpace(filtro))
                return new ObservableCollection<Usuario>();

            filtro = filtro.Trim();

            var lista = await _db.Usuarios
                .Where(u => u.EstaActivo &&
                            (
                              u.Dni == filtro
                              || EF.Functions.Like(u.Nombre + " " + u.Apellidos, $"%{filtro}%")
                              || EF.Functions.Like(u.Apellidos + " " + u.Nombre, $"%{filtro}%")
                            ))
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
            return await _db.Usuarios
                            .FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Crea un nuevo usuario. Devuelve true si tuvo éxito, false si el DNI ya existe.
        /// </summary>
        public async Task<bool> CreateUsuarioAsync(Usuario u)
        {
            // Evitar duplicar DNI
            bool existe = await _db.Usuarios.AnyAsync(x => x.Dni == u.Dni);
            if (existe) return false;

            u.FechaRegistro = DateTime.Now;
            u.EstaActivo = true;

            _db.Usuarios.Add(u);
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Actualiza un usuario existente. Devuelve true si tuvo éxito, false si el DNI se duplica.
        /// </summary>
        public async Task<bool> UpdateUsuarioAsync(Usuario u)
        {
            var ex = await _db.Usuarios.FirstOrDefaultAsync(x => x.Id == u.Id);
            if (ex == null) return false;

            // Verificar que no haya otro usuario con el mismo DNI
            bool dniDuplicado = await _db.Usuarios
                .AnyAsync(x => x.Dni == u.Dni && x.Id != u.Id);
            if (dniDuplicado) return false;

            ex.Dni = u.Dni;
            ex.Apellidos = u.Apellidos;
            ex.Nombre = u.Nombre;
            ex.Email = u.Email;
            ex.Telefono = u.Telefono;
            ex.EstaActivo = u.EstaActivo;
            // ex.FechaRegistro permanece intacta

            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Cambia el estado de "Activo" de un usuario (activar o desactivar).
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
