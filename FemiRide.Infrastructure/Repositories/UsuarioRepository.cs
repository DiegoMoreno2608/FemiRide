using FemiRide.Domain.Interface;
using FemiRide.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiRide.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MyDbContext _db;

        public UsuarioRepository(MyDbContext db) => _db = db;

        public async Task<bool> CorreoExisteAsync(string correo)
            => await _db.Usuarios.AnyAsync(u => u.Correo == correo);

        public async Task AgregarAsync(Usuario usuario)
        {
            _db.Usuarios.Add(usuario);
            await _db.SaveChangesAsync();
        }
        public async Task<Usuario?> ObtenerPorCorreoAsync(string correo)
        {
            return await _db.Usuarios
                .FirstOrDefaultAsync(u => u.Correo == correo);
        }
    }
}
