using System;
namespace Reserva_de_Espacios_Biblioteca.Data.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Dni { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public bool EstaActivo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}