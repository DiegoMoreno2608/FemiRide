using System;
using System.Collections.Generic;

namespace FemiRide.Persistence.Context
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string Correo { get; set; } = null!;
        public string ContraseñaHash { get; set; } = null!;
        public bool? Estado { get; set; }
        public DateTime? CreadoEn { get; set; }
    }
}
