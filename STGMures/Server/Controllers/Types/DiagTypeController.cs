using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]

    public class DiagTypeController : ControllerBase
    {
        private readonly StgMuresContext _context;

        public DiagTypeController(StgMuresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiagnostics()
        {
            var ret = await _context.Diagnostics.ToListAsync();
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiagnostic(int id)
        {
            var dbDiagnostic = await _context.Diagnostics.FirstOrDefaultAsync(p => p.Id == id);
            if (dbDiagnostic == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            return Ok(dbDiagnostic);
        }

        [HttpPost]
        public async Task<IActionResult> AddDiagnostic(Diagnostic diagnostic)
        {
            _context.Diagnostics.Add(diagnostic);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(await _context.Diagnostics.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiagnostic(Diagnostic diagnostic)
        {
            var dbDiagnostic = await _context.Diagnostics.FirstOrDefaultAsync(p => p.Id == diagnostic.Id);
            if (dbDiagnostic == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbDiagnostic.Name = diagnostic.Name;

            await _context.SaveChangesAsync();

            return Ok(dbDiagnostic);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnostic(int id) // trebuie sa fac si una cu isDeleted
        {
            var dbDiagnostic = await _context.Diagnostics.FirstOrDefaultAsync(p => p.Id == id);
            if (dbDiagnostic == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            _context.Diagnostics.Remove(dbDiagnostic);
            await _context.SaveChangesAsync();

            return Ok(await _context.Diagnostics.ToListAsync());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDeleteDiagnostic(int id, Diagnostic diagnostic) //soft delete
        {
            var dbDiagnostic = await _context.Diagnostics.FirstOrDefaultAsync(p => p.Id == diagnostic.Id);
            if (dbDiagnostic == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbDiagnostic.Name = diagnostic.Name;
            //dbDiagnostic.isDeleted = 1;


            await _context.SaveChangesAsync();

            return Ok(dbDiagnostic);
        }




    }
}

