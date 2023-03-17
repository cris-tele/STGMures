using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class TreatTypeController : ControllerBase
    {
        private readonly StgMuresContext _context;

        public TreatTypeController(StgMuresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTreatments()
        {
            var ret = await _context.Treatments.ToListAsync();
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTreatment(int id)
        {
            var dbTreatment = await _context.Treatments.FirstOrDefaultAsync(p => p.Id == id);
            if (dbTreatment == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            return Ok(dbTreatment);
        }

        [HttpPost]
        public async Task<IActionResult> AddTreatment(Treatment treatment)
        {
            _context.Treatments.Add(treatment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(await _context.Treatments.ToListAsync());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTreatment(Treatment treatment)
        {
            var dbTreatment = await _context.Treatments.FirstOrDefaultAsync(p => p.Id == treatment.Id);
            if (dbTreatment == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbTreatment.Name = treatment.Name;

            await _context.SaveChangesAsync();

            return Ok(dbTreatment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTreatment(int id) // trebuie sa fac si una cu isDeleted
        {
            var dbTreatment = await _context.Treatments.FirstOrDefaultAsync(p => p.Id == id);
            if (dbTreatment == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            _context.Treatments.Remove(dbTreatment);
            await _context.SaveChangesAsync();

            return Ok(await _context.Treatments.ToListAsync());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDeleteTreatment(int id, Treatment treatment) //soft delete
        {
            var dbTreatment = await _context.Treatments.FirstOrDefaultAsync(p => p.Id == treatment.Id);
            if (dbTreatment == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbTreatment.Name = treatment.Name;
            //dbTreatment.isDeleted = 1;


            await _context.SaveChangesAsync();

            return Ok(dbTreatment);
        }
    }
}
