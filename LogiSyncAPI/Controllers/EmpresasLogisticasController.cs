using LogiSyncAPI.Data;
using LogiSyncAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogiSyncAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasLogisticasController : ControllerBase
    {
        private readonly LogiSyncContext _context;

        public EmpresasLogisticasController(LogiSyncContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresaLogistica>>> GetEmpresasLogisticas()
        {
            return await _context.EmpresasLogisticas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresaLogistica>> GetEmpresaLogistica(int id)
        {
            var empresa = await _context.EmpresasLogisticas.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaLogistica>> PostEmpresaLogistica(EmpresaLogistica empresa)
        {
            _context.EmpresasLogisticas.Add(empresa);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpresaLogistica), new { id = empresa.Id }, empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresaLogistica(int id, EmpresaLogistica empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();
            }

            _context.Entry(empresa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaLogisticaExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresaLogistica(int id)
        {
            var empresa = await _context.EmpresasLogisticas.FindAsync(id);

            if (empresa == null)
            {
                return NotFound();
            }

            _context.EmpresasLogisticas.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaLogisticaExists(int id)
        {
            return _context.EmpresasLogisticas.Any(e => e.Id == id);
        }
    }
}