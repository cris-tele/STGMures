using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class SurgeryTypeController : ControllerBase
    {
        private readonly StgMuresContext _context;

        public SurgeryTypeController(StgMuresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiagnostics()
        {
            var ret = await _context.Surgeries.ToListAsync();
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiagnostic(int id)
        {
            var dbDiagnostic = await _context.Surgeries.FirstOrDefaultAsync(p => p.Id == id);
            if (dbDiagnostic == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            return Ok(dbDiagnostic);
        }

        [HttpPost]
        public async Task<IActionResult> AddDiagnostic(Surgery surgery)
        {
            _context.Surgeries.Add(surgery);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(await _context.Surgeries.ToListAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiagnostic(Surgery surgery)
        {
            var dbDiagnostic = await _context.Surgeries.FirstOrDefaultAsync(p => p.Id == surgery.Id);
            if (dbDiagnostic == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbDiagnostic.Description = surgery.Description;

            await _context.SaveChangesAsync();

            return Ok(dbDiagnostic);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnostic(int id) // trebuie sa fac si una cu isDeleted
        {
            var dbDiagnostic = await _context.Surgeries.FirstOrDefaultAsync(p => p.Id == id);
            if (dbDiagnostic == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            _context.Surgeries.Remove(dbDiagnostic);
            await _context.SaveChangesAsync();

            return Ok(await _context.Surgeries.ToListAsync());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDeleteDiagnostic(int id, Surgery surgery) //soft delete
        {
            var dbDiagnostic = await _context.Surgeries.FirstOrDefaultAsync(p => p.Id == surgery.Id);
            if (dbDiagnostic == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbDiagnostic.Description = surgery.Description;
            //dbDiagnostic.isDeleted = 1;


            await _context.SaveChangesAsync();

            return Ok(dbDiagnostic);
        }
    }
}
