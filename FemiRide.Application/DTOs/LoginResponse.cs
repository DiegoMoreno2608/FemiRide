using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiRide.Application.DTOs
{
    public class LoginResponse
    {
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
