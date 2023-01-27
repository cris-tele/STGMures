using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class ConsCategoryController : ControllerBase
    {
        private readonly StgMuresContext _context;

        public ConsCategoryController(StgMuresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetConsumableCategories()
        {
            var ret = await _context.ConsumableCategories.ToListAsync();
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsumableCategory(int id)
        {
            var dbConsumableCategory = await _context.ConsumableCategories.FirstOrDefaultAsync(p => p.Id == id);
            if (dbConsumableCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            return Ok(dbConsumableCategory);
        }

        [HttpPost]
        public async Task<IActionResult> AddConsumableCategory(ConsumableCategory consumableCategory)
        {
            _context.ConsumableCategories.Add(consumableCategory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(await _context.ConsumableCategories.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConsumableCategory(ConsumableCategory consumableCategory)
        {
            var dbConsumableCategory = await _context.ConsumableCategories.FirstOrDefaultAsync(p => p.Id == consumableCategory.Id);
            if (dbConsumableCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbConsumableCategory.Name = consumableCategory.Name;

            await _context.SaveChangesAsync();

            return Ok(dbConsumableCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumableCategory(int id) // trebuie sa fac si una cu isDeleted
        {
            var dbConsumableCategory = await _context.ConsumableCategories.FirstOrDefaultAsync(p => p.Id == id);
            if (dbConsumableCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            _context.ConsumableCategories.Remove(dbConsumableCategory);
            await _context.SaveChangesAsync();

            return Ok(await _context.ConsumableCategories.ToListAsync());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDeleteConsumableCategory(int id, ConsumableCategory consumableCategory) //soft delete
        {
            var dbConsumableCategory = await _context.ConsumableCategories.FirstOrDefaultAsync(p => p.Id == consumableCategory.Id);
            if (dbConsumableCategory == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbConsumableCategory.Name = consumableCategory.Name;
            //dbConsumableCategory.isDeleted = 1;


            await _context.SaveChangesAsync();

            return Ok(dbConsumableCategory);
        }
    }
}
