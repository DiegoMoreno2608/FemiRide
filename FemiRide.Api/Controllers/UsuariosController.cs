using FemiRide.Application.DTOs;
using FemiRide.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FemiRide.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuariosController(UsuarioService service) => _service = service;

        [HttpPost("registro")]
        public async Task<IActionResult> Registrar([FromBody] RegistrarUsuarioRequest request)
        {
            try
            {
                await _service.RegistrarUsuarioAsync(request);
                return Ok(new { mensaje = "Usuario registrado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _service.LoginAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { error = ex.Message });
            }
        }
    }
}
