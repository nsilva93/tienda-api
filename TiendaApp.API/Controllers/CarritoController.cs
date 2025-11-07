using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TiendaApp.API.Models.Carrito;
using TiendaApp.Business.Interfaces;

namespace TiendaApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }

        private int GetClienteId()
        {
            return int.Parse(User.Claims.First(c => c.Type == "sub").Value);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int clienteId = GetClienteId();
            var result = await _carritoService.GetCartAsync(clienteId);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(AddToCartRequest req)
        {
            int clienteId = GetClienteId();
            var success = await _carritoService.AddToCartAsync(clienteId, req.ArticuloId);

            if (!success) return BadRequest("Artículo no encontrado.");
            return Ok(new { message = "Artículo agregado al carrito" });
        }

        [HttpPost("remove")]
        public async Task<IActionResult> Remove(RemoveFromCartRequest req)
        {
            int clienteId = GetClienteId();
            var success = await _carritoService.RemoveFromCartAsync(clienteId, req.ArticuloId);

            if (!success) return NotFound("El artículo no está en el carrito.");
            return Ok(new { message = "Artículo removido del carrito" });
        }
    }
}