using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TiendaApp.Business.Interfaces;
using TiendaApp.Entities.DTOs.TiendaArticulo;

namespace TiendaApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendaArticuloController : ControllerBase
    {
        private readonly ITiendaArticuloService _service;

        public TiendaArticuloController(ITiendaArticuloService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CrearRelacion(CrearTiendaArticuloRequest request)
        {
            var success = await _service.CrearRelacionAsync(request);
            if (success)
                return Ok("Relación creada");

            return BadRequest("No se pudo crear la relación");
        }

        [HttpGet("tienda/{tiendaId}")]
        public async Task<IActionResult> GetArticulosPorTienda(int tiendaId)
        {
            var result = await _service.GetArticulosPorTienda(tiendaId);
            return Ok(result);
        }

        [HttpGet("articulo/{articuloId}")]
        public async Task<IActionResult> GetTiendasPorArticulo(int articuloId)
        {
            var result = await _service.GetTiendasPorArticulo(articuloId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var success = await _service.EliminarRelacionAsync(id);
            if (success)
                return NoContent();

            return NotFound();
        }
    }
}