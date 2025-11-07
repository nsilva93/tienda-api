using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TiendaApp.API.Models.Auth;
using TiendaApp.Business.Interfaces;
using TiendaApp.Entities;

namespace TiendaApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest req)
        {
            var cliente = new Cliente
            {
                Nombre = req.Nombre,
                Apellidos = req.Apellidos,
                Direccion = req.Direccion,
                Email = req.Email
            };

            var result = await _auth.RegisterAsync(cliente, req.Password);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest req)
        {
            var cliente = await _auth.LoginAsync(req.Email, req.Password);

            if (cliente == null)
                return Unauthorized(new { message = "Credenciales inválidas" });

            var token = _auth.GenerateJwtToken(cliente);

            return Ok(new { token });
        }
    }
}
