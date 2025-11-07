using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TiendaApp.Business.Interfaces;
using TiendaApp.Entities;

namespace TiendaApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloService _service;

        public ArticulosController(IArticuloService service)
        {
            _service = service;
        }

        /// Obtiene todos los artículos disponibles.
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        /// Obtiene un artículo por su ID.
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// Crea un nuevo artículo.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Articulo entity)
        {
            var result = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        /// Actualiza un artículo existente.
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Articulo entity)
        {
            var result = await _service.UpdateAsync(id, entity);
            if (!result) return NotFound();
            return NoContent();
        }

        /// Elimina un artículo por ID.
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
