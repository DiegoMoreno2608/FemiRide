using FemiRide.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiRide.Domain.Interface
{
    public interface IUsuarioRepository
    {
        Task<bool> CorreoExisteAsync(string correo);
        Task AgregarAsync(Usuario usuario);
        Task<Usuario?> ObtenerPorCorreoAsync(string correo);
    }
}
