using LogiSyncAPI.Data;
using LogiSyncAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogiSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController : ControllerBase
    {
        private readonly LogiSyncContext _context;

        public EnviosController(LogiSyncContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Envio>>> GetEnvios()
        {
            return await _context.Envios
                .Include(e => e.EmpresaLogistica)
                .Include(e => e.EstadoOriginal)
                .Include(e => e.EstadoNormalizado)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Envio>> GetEnvio(int id)
        {
            var envio = await _context.Envios
                .Include(e => e.EmpresaLogistica)
                .Include(e => e.EstadoOriginal)
                .Include(e => e.EstadoNormalizado)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (envio == null)
            {
                return NotFound();
            }

            return envio;
        }

        [HttpPost]
        public async Task<ActionResult<Envio>> PostEnvio(Envio envio)
        {
            var traduccion = await _context.TraduccionesEstados
                .FirstOrDefaultAsync(t => t.EstadoOriginalId == envio.EstadoOriginalId);

            if (traduccion != null)
            {
                envio.EstadoNormalizadoId = traduccion.EstadoNormalizadoId;
            }

            _context.Envios.Add(envio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnvio), new { id = envio.Id }, envio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvio(int id, Envio envio)
        {
            if (id != envio.Id)
            {
                return BadRequest();
            }

            var traduccion = await _context.TraduccionesEstados
                .FirstOrDefaultAsync(t => t.EstadoOriginalId == envio.EstadoOriginalId);

            if (traduccion != null)
            {
                envio.EstadoNormalizadoId = traduccion.EstadoNormalizadoId;
            }

            _context.Entry(envio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvioExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnvio(int id)
        {
            var envio = await _context.Envios.FindAsync(id);

            if (envio == null)
            {
                return NotFound();
            }

            _context.Envios.Remove(envio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnvioExists(int id)
        {
            return _context.Envios.Any(e => e.Id == id);
        }
    }
}