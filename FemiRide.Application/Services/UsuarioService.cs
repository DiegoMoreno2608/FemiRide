using FemiRide.Application.DTOs;
using FemiRide.Domain.Interface;
using FemiRide.Infrastructure.Security;
using FemiRide.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FemiRide.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repo;
        private readonly IPasswordHasher _hasher;
        private readonly IJwtService _jwtService;

        public UsuarioService(IUsuarioRepository repo, IPasswordHasher hasher, IJwtService jwtService)
        {
            _repo = repo;
            _hasher = hasher;
            _jwtService = jwtService;
        }

        public async Task RegistrarUsuarioAsync(RegistrarUsuarioRequest request)
        {
            if (await _repo.CorreoExisteAsync(request.Correo))
                throw new Exception("El correo ya está registrado.");

            var usuario = new Usuario
            {
                Nombre = request.Nombre,
                Correo = request.Correo,
                ContraseñaHash = _hasher.Hash(request.Contraseña)
            };

            await _repo.AgregarAsync(usuario);
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var usuario = await _repo.ObtenerPorCorreoAsync(loginRequest.Correo);
            if (usuario is null || usuario.Estado != true)
            {
                throw new Exception("Credenciales inválidas");
            }
            if (_hasher.Verify(loginRequest.Contraseña, usuario.ContraseñaHash))
                throw new Exception("Credenciales inválidas");
            string token = _jwtService?.GenerarToken(usuario) ?? string.Empty;

            return new LoginResponse
            {
                Nombre = usuario.Nombre ?? string.Empty,
                Correo = usuario.Correo,
                Token = token,
            };
        }
    }
}
