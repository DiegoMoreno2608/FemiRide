using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiRide.Application.DTOs
{
    public class RegistrarUsuarioRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;
    }
}
