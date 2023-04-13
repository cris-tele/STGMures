using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]

    public class SProcCategoryController : ControllerBase
    {
        private readonly StgMuresContext _context;

        public SProcCategoryController(StgMuresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTreatmentCategories()
        {
            var ret = await _context.SurgicalCategories.ToListAsync();
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSurgicalCategory(int id)
        {
            var dbSurgicalProcedure = await _context.SurgicalCategories.FirstOrDefaultAsync(p => p.Id == id);
            if (dbSurgicalProcedure == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            return Ok(dbSurgicalProcedure);
        }

        [HttpPost]
        public async Task<IActionResult> AddSurgicalCategory(SurgicalCategory surgicalProcedure)
        {
            surgicalProcedure.Id = 0; // database generated
            _context.SurgicalCategories.Add(surgicalProcedure);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(await _context.SurgicalCategories.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurgicalCategory(SurgicalCategory surgicalProcedure)
        {
            var dbSurgicalProcedure = await _context.SurgicalCategories.FirstOrDefaultAsync(p => p.Id == surgicalProcedure.Id);
            if (dbSurgicalProcedure == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbSurgicalProcedure.Name = surgicalProcedure.Name;

            await _context.SaveChangesAsync();

            return Ok(dbSurgicalProcedure);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurgicalCategory(int id) // trebuie sa fac si una cu isDeleted
        {
            var dbSurgicalProcedure = await _context.SurgicalCategories.FirstOrDefaultAsync(p => p.Id == id);
            if (dbSurgicalProcedure == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            _context.SurgicalCategories.Remove(dbSurgicalProcedure);
            await _context.SaveChangesAsync();

            return Ok(await _context.SurgicalCategories.ToListAsync());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDeleteSurgicalProcedure(int id, SurgicalCategory surgicalProcedure) //soft delete
        {
            var dbSurgicalProcedure = await _context.SurgicalCategories.FirstOrDefaultAsync(p => p.Id == surgicalProcedure.Id);
            if (dbSurgicalProcedure == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbSurgicalProcedure.Name = surgicalProcedure.Name;
            //dbSurgicalProcedure.isDeleted = 1;


            await _context.SaveChangesAsync();

            return Ok(dbSurgicalProcedure);
        }
    }
}
