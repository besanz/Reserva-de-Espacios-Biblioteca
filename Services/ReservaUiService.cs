using System;
using System.Collections.Generic;
using System.Linq;
using Reserva_de_Espacios_Biblioteca.Data.Entities;

namespace Reserva_de_Espacios_Biblioteca.Services
{
    public class ReservaUIService
    {
        private readonly List<Reserva> _reservas;
        private readonly List<Cabina> _cabinas;
        private readonly List<Usuario> _usuarios;
        private int _ultimoIdReserva;
        private int _ultimoIdUsuario;

        public ReservaUIService()
        {
            // En un escenario real vendrían de la BD
            _cabinas = new List<Cabina>
            {
                new Cabina { Id = 1, Nombre = "Cabina Individual", Capacidad = 1 },
                new Cabina { Id = 2, Nombre = "Cabina Grupal",    Capacidad = 4 }
            };
            _usuarios = new List<Usuario>();
            _reservas = new List<Reserva>();

            AgregarUsuariosPrueba();
            AgregarReservasPrueba();
        }

        private void AgregarUsuariosPrueba()
        {
            // Creación de usuarios de ejemplo. Asignamos Ids automáticos:
            AgregarUsuario(new Usuario
            {
                Dni = "12345678A",
                Nombre = "Juan",
                Apellidos = "Pérez García",
                Email = "juan.perez@ejemplo.com",
                Telefono = "612345678",
                EstaActivo = true
            });

            AgregarUsuario(new Usuario
            {
                Dni = "87654321B",
                Nombre = "María",
                Apellidos = "López Sánchez",
                Email = "maria.lopez@ejemplo.com",
                Telefono = "687654321",
                EstaActivo = true
            });
        }

        private void AgregarReservasPrueba()
        {
            // Supongamos que el primer usuario (Id = 1) y el segundo (Id = 2)
            AgregarReserva(new Reserva
            {
                CabinaId = 1,
                UsuarioId = 1, // Antes era SocioDni = "12345678A"
                Inicio = DateTime.Today.AddHours(10),
                Fin = DateTime.Today.AddHours(11)
            });
            AgregarReserva(new Reserva
            {
                CabinaId = 2,
                UsuarioId = 2, // Antes era SocioDni = "87654321B"
                Inicio = DateTime.Today.AddDays(1).AddHours(16),
                Fin = DateTime.Today.AddDays(1).AddHours(18)
            });
        }

        // ——— Métodos de Cabinas ———
        public List<Cabina> ObtenerTodasLasCabinas() => _cabinas;
        public Cabina? ObtenerCabinaPorId(int id) => _cabinas.FirstOrDefault(c => c.Id == id);

        // ——— Métodos de Usuarios ———
        public List<Usuario> ObtenerTodosLosUsuarios() => _usuarios;
        public Usuario? ObtenerUsuarioPorDni(string dni) => _usuarios.FirstOrDefault(u => u.Dni == dni);

        public bool AgregarUsuario(Usuario u)
        {
            if (_usuarios.Any(x => x.Dni == u.Dni)) return false;
            u.Id = ++_ultimoIdUsuario;
            _usuarios.Add(u);
            return true;
        }

        public bool ActualizarUsuario(Usuario u)
        {
            var ex = _usuarios.FirstOrDefault(x => x.Id == u.Id);
            if (ex == null) return false;
            if (_usuarios.Any(x => x.Dni == u.Dni && x.Id != u.Id)) return false;
            ex.Dni = u.Dni;
            ex.Nombre = u.Nombre;
            ex.Apellidos = u.Apellidos;
            ex.Email = u.Email;
            ex.Telefono = u.Telefono;
            ex.EstaActivo = u.EstaActivo;
            return true;
        }

        // ——— Métodos de Reservas ———
        public List<Reserva> ObtenerTodasLasReservas() => _reservas;

        public List<Reserva> ObtenerReservasPorFecha(DateTime fecha) =>
            _reservas.Where(r => r.Inicio.Date == fecha.Date).ToList();

        public List<Reserva> ObtenerReservasPorCabina(int cabinaId) =>
            _reservas.Where(r => r.CabinaId == cabinaId).ToList();

        public List<Reserva> ObtenerReservasPorUsuario(int usuarioId) =>
            _reservas.Where(r => r.UsuarioId == usuarioId).ToList();

        public Reserva? ObtenerReservaPorId(int id) =>
            _reservas.FirstOrDefault(r => r.Id == id);

        public bool ExisteConflictoReserva(Reserva nueva)
        {
            return _reservas.Any(r =>
                r.Id != nueva.Id &&
                r.CabinaId == nueva.CabinaId &&
                r.Inicio < nueva.Fin &&
                r.Fin > nueva.Inicio
            );
        }

        public bool AgregarReserva(Reserva r)
        {
            if (ExisteConflictoReserva(r)) return false;
            r.Id = ++_ultimoIdReserva;
            _reservas.Add(r);
            return true;
        }

        public bool ActualizarReserva(Reserva r)
        {
            if (ExisteConflictoReserva(r)) return false;
            var ex = _reservas.FirstOrDefault(x => x.Id == r.Id);
            if (ex == null) return false;
            ex.CabinaId = r.CabinaId;
            ex.UsuarioId = r.UsuarioId; // Cambiado aquí
            ex.Inicio = r.Inicio;
            ex.Fin = r.Fin;
            return true;
        }

        public bool EliminarReserva(int id)
        {
            var ex = _reservas.FirstOrDefault(r => r.Id == id);
            if (ex == null) return false;
            _reservas.Remove(ex);
            return true;
        }

        // Simular consulta externa de usuarios
        public Usuario ConsultarUsuarioExterno(string dni)
        {
            // Simulación de servicio externo
            System.Threading.Thread.Sleep(500); // Retraso simulado

            // Devolvemos un usuario ficticio basado en el DNI
            return new Usuario
            {
                Dni = dni,
                Nombre = $"Usuario{dni.Substring(0, 3)}",
                Apellidos = $"Externo{dni.Substring(3, 3)}",
                Email = $"usuario{dni.Substring(0, 4)}@ejemplo.com",
                Telefono = $"6{dni.Substring(0, 8)}",
                EstaActivo = true
            };
        }

        public bool RegistrarSalida(int reservaId)
        {
            var reserva = _reservas.FirstOrDefault(r => r.Id == reservaId);
            if (reserva == null)
                return false;

            // En un escenario real marcaríamos la “salida” en la BD
            return true;
        }
    }
}
