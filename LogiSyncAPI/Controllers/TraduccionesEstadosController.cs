using LogiSyncAPI.Data;
using LogiSyncAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogiSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraduccionesEstadosController : ControllerBase
    {
        private readonly LogiSyncContext _context;

        public TraduccionesEstadosController(LogiSyncContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TraduccionEstado>>> Get()
        {
            return await _context.TraduccionesEstados
                .Include(t => t.EstadoOriginal)
                .Include(t => t.EstadoNormalizado)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<TraduccionEstado>> Post(TraduccionEstado traduccion)
        {
            _context.TraduccionesEstados.Add(traduccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = traduccion.Id }, traduccion);
        }
    }
}