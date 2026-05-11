using LogiSyncAPI.Data;
using LogiSyncAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogiSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosOriginalesController : ControllerBase
    {
        private readonly LogiSyncContext _context;

        public EstadosOriginalesController(LogiSyncContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EstadoOriginal>>> GetEstadosOriginales()
        {
            return await _context.EstadosOriginales
                .Include(e => e.EmpresaLogistica)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EstadoOriginal>> GetEstadoOriginal(int id)
        {
            var estado = await _context.EstadosOriginales
                .Include(e => e.EmpresaLogistica)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        [HttpPost]
        public async Task<ActionResult<EstadoOriginal>> PostEstadoOriginal(EstadoOriginal estado)
        {
            _context.EstadosOriginales.Add(estado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstadoOriginal), new { id = estado.Id }, estado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstadoOriginal(int id, EstadoOriginal estado)
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
                if (!EstadoOriginalExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoOriginal(int id)
        {
            var estado = await _context.EstadosOriginales.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            _context.EstadosOriginales.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoOriginalExists(int id)
        {
            return _context.EstadosOriginales.Any(e => e.Id == id);
        }
    }
}