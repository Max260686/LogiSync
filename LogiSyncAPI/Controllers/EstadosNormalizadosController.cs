using LogiSyncAPI.Data;
using LogiSyncAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogiSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosNormalizadosController : ControllerBase
    {
        private readonly LogiSyncContext _context;

        public EstadosNormalizadosController(LogiSyncContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoNormalizado>>> GetEstadosNormalizados()
        {
            return await _context.EstadosNormalizados.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoNormalizado>> GetEstadoNormalizado(int id)
        {
            var estado = await _context.EstadosNormalizados.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        [HttpPost]
        public async Task<ActionResult<EstadoNormalizado>> PostEstadoNormalizado(EstadoNormalizado estado)
        {
            _context.EstadosNormalizados.Add(estado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstadoNormalizado), new { id = estado.Id }, estado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoNormalizado(int id, EstadoNormalizado estado)
        {
            if (id != estado.Id)
            {
                return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoNormalizadoExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoNormalizado(int id)
        {
            var estado = await _context.EstadosNormalizados.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            _context.EstadosNormalizados.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoNormalizadoExists(int id)
        {
            return _context.EstadosNormalizados.Any(e => e.Id == id);
        }
    }
}