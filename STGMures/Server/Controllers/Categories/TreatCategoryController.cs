using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class TreatCategoryController : ControllerBase
    {

        private readonly StgMuresContext _context;

        public TreatCategoryController(StgMuresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTreatmentCategories()
        {
            var ret = await _context.TreatmentCategories.ToListAsync();
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTreatmentCategory(int id)
        {
            var dbTreatmentCategory = await _context.TreatmentCategories.FirstOrDefaultAsync(p => p.Id == id);
            if (dbTreatmentCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            return Ok(dbTreatmentCategory);
        }

        [HttpPost]
        public async Task<IActionResult> AddTreatmentCategory(TreatmentCategory treatmentCategory)
        {
            treatmentCategory.Id = 0; 
            _context.TreatmentCategories.Add(treatmentCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(await _context.TreatmentCategories.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTreatmentCategory(TreatmentCategory treatmentCategory)
        {
            var dbTreatmentCategory = await _context.TreatmentCategories.FirstOrDefaultAsync(p => p.Id == treatmentCategory.Id );
            if (dbTreatmentCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbTreatmentCategory.Name = treatmentCategory.Name;
            dbTreatmentCategory.Type = treatmentCategory.Type;

            await _context.SaveChangesAsync();

            return Ok(dbTreatmentCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreatmentCategory(int id) // trebuie sa fac si una cu isDeleted
        {
            var dbTreatmentCategory = await _context.TreatmentCategories.FirstOrDefaultAsync(p => p.Id == id);
            if (dbTreatmentCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            _context.TreatmentCategories.Remove(dbTreatmentCategory);
            await _context.SaveChangesAsync();

            return Ok(await _context.TreatmentCategories.ToListAsync());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDeleteTreatmentCategory(int id, TreatmentCategory treatmentCategory) //soft delete
        {
            var dbTreatmentCategory = await _context.TreatmentCategories.FirstOrDefaultAsync(p => p.Id == treatmentCategory.Id);
            if (dbTreatmentCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbTreatmentCategory.Name = treatmentCategory.Name;
            //dbTreatmentCategory.isDeleted = 1;


            await _context.SaveChangesAsync();

            return Ok(dbTreatmentCategory);
        }




    }
}
