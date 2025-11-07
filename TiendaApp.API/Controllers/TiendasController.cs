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
    public class TiendasController : ControllerBase
    {
        private readonly ITiendaService _service;

        public TiendasController(ITiendaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tienda = await _service.GetByIdAsync(id);
            if (tienda == null) return NotFound();
            return Ok(tienda);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tienda entity)
        {
            var tienda = await _service.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = tienda.Id }, tienda);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Tienda entity)
        {
            var success = await _service.UpdateAsync(id, entity);

            if (success)
                return NoContent();

            return NotFound();
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (success)
                return NoContent();

            return NotFound();
        }

    }
}
