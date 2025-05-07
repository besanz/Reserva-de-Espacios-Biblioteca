using System;

namespace Reserva_de_Espacios_Biblioteca.Data.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public int CabinaId { get; set; }
        public string SocioDni { get; set; } = string.Empty;
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
    }
}
