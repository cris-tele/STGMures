using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]

    public class DCategoryController : ControllerBase
    {

        private readonly StgMuresContext _context;

        public DCategoryController(StgMuresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiagnosticCategories()
        {
            var ret = await _context.DiagnosticCategories.ToListAsync();
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiagnosticCategory(int id)
        {
            var dbDiagnosticCategory = await _context.DiagnosticCategories.FirstOrDefaultAsync(p => p.Id == id);
            if (dbDiagnosticCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            return Ok(dbDiagnosticCategory);
        }

        [HttpPost]
        public async Task<IActionResult> AddDiagnosticCategory(DiagnosticCategory diagnosticCategory)
        {
            _context.DiagnosticCategories.Add(diagnosticCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(await _context.DiagnosticCategories.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiagnosticCategory(DiagnosticCategory diagnosticCategory)
        {
            var dbDiagnosticCategory = await _context.DiagnosticCategories.FirstOrDefaultAsync(p => p.Id == diagnosticCategory.Id);
            if (dbDiagnosticCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbDiagnosticCategory.Name = diagnosticCategory.Name;

            await _context.SaveChangesAsync();

            return Ok(dbDiagnosticCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiagnosticCategory(int id) // trebuie sa fac si una cu isDeleted
        {
            var dbDiagnosticCategory = await _context.DiagnosticCategories.FirstOrDefaultAsync(p => p.Id == id);
            if (dbDiagnosticCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            _context.DiagnosticCategories.Remove(dbDiagnosticCategory);
            await _context.SaveChangesAsync();

            return Ok(await _context.DiagnosticCategories.ToListAsync());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDeleteDiagnosticCategory(int id, DiagnosticCategory diagnosticCategory) //soft delete
        {
            var dbDiagnosticCategory = await _context.DiagnosticCategories.FirstOrDefaultAsync(p => p.Id == diagnosticCategory.Id);
            if (dbDiagnosticCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbDiagnosticCategory.Name = diagnosticCategory.Name;
            //dbDiagnosticCategory.isDeleted = 1;


            await _context.SaveChangesAsync();

            return Ok(dbDiagnosticCategory);
        }




    }

}
