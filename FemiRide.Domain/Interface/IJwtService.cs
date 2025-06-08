using FemiRide.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiRide.Domain.Interface
{
    public interface IJwtService
    {
        string GenerarToken(Usuario usuario);
    }
}
