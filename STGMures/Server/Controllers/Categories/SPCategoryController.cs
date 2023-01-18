using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]

    public class SPCategoryController : ControllerBase
    {
        private readonly StgMuresContext _context;

        public SPCategoryController(StgMuresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTreatmentCategories()
        {
            var ret = await _context.SurgicalProcedures.ToListAsync();
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurgicalProcedure(int id)
        {
            var dbSurgicalProcedure = await _context.SurgicalProcedures.FirstOrDefaultAsync(p => p.Id == id);
            if (dbSurgicalProcedure == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            return Ok(dbSurgicalProcedure);
        }

        [HttpPost]
        public async Task<IActionResult> AddSurgicalProcedure(SurgicalProcedure SurgicalProcedure)
        {
            _context.SurgicalProcedures.Add(SurgicalProcedure);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(await _context.SurgicalProcedures.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurgicalProcedure(SurgicalProcedure SurgicalProcedure)
        {
            var dbSurgicalProcedure = await _context.SurgicalProcedures.FirstOrDefaultAsync(p => p.Id == SurgicalProcedure.Id);
            if (dbSurgicalProcedure == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbSurgicalProcedure.Name = SurgicalProcedure.Name;

            await _context.SaveChangesAsync();

            return Ok(dbSurgicalProcedure);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurgicalProcedure(int id) // trebuie sa fac si una cu isDeleted
        {
            var dbSurgicalProcedure = await _context.SurgicalProcedures.FirstOrDefaultAsync(p => p.Id == id);
            if (dbSurgicalProcedure == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            _context.SurgicalProcedures.Remove(dbSurgicalProcedure);
            await _context.SaveChangesAsync();

            return Ok(await _context.SurgicalProcedures.ToListAsync());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDeleteSurgicalProcedure(int id, SurgicalProcedure SurgicalProcedure) //soft delete
        {
            var dbSurgicalProcedure = await _context.SurgicalProcedures.FirstOrDefaultAsync(p => p.Id == SurgicalProcedure.Id);
            if (dbSurgicalProcedure == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbSurgicalProcedure.Name = SurgicalProcedure.Name;
            //dbSurgicalProcedure.isDeleted = 1;


            await _context.SaveChangesAsync();

            return Ok(dbSurgicalProcedure);
        }
    }
}
