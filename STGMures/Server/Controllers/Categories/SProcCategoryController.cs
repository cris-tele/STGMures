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
        public async Task<IActionResult> AddSurgicalProcedure(SurgicalProcedure surgicalProcedure)
        {
            surgicalProcedure.Id = 0; // database generated
            _context.SurgicalProcedures.Add(surgicalProcedure);
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
        public async Task<IActionResult> UpdateSurgicalProcedure(SurgicalProcedure surgicalProcedure)
        {
            var dbSurgicalProcedure = await _context.SurgicalProcedures.FirstOrDefaultAsync(p => p.Id == surgicalProcedure.Id);
            if (dbSurgicalProcedure == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbSurgicalProcedure.Name = surgicalProcedure.Name;
            dbSurgicalProcedure.ParentId = surgicalProcedure.ParentId;

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
        public async Task<IActionResult> SoftDeleteSurgicalProcedure(int id, SurgicalProcedure surgicalProcedure) //soft delete
        {
            var dbSurgicalProcedure = await _context.SurgicalProcedures.FirstOrDefaultAsync(p => p.Id == surgicalProcedure.Id);
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
