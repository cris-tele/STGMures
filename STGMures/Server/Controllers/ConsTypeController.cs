using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StgMures.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]

    public class ConsTypeController : ControllerBase
    {
        private readonly StgMuresContext _context;

        public ConsTypeController(StgMuresContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetConsumables()
        {
            var ret = await _context.Consumables.ToListAsync();
            return Ok(ret);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetConsumable(int id)
        {
            var dbConsumable = await _context.Consumables.FirstOrDefaultAsync(p => p.Id == id);
            if (dbConsumable == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            return Ok(dbConsumable);
        }

        [HttpPost]
        public async Task<IActionResult> AddConsumable(Consumable consumable)
        {
            _context.Consumables.Add(consumable);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(await _context.Consumables.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateConsumable(Consumable consumable)
        {
            var dbConsumable = await _context.Consumables.FirstOrDefaultAsync(p => p.Id == consumable.Id);
            if (dbConsumable == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbConsumable.Name = consumable.Name;

            await _context.SaveChangesAsync();

            return Ok(dbConsumable);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsumable(int id) // trebuie sa fac si una cu isDeleted
        {
            var dbConsumable = await _context.Consumables.FirstOrDefaultAsync(p => p.Id == id);
            if (dbConsumable == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            _context.Consumables.Remove(dbConsumable);
            await _context.SaveChangesAsync();

            return Ok(await _context.Consumables.ToListAsync());
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> SoftDeleteConsumable(int id, Consumable consumable) //soft delete
        {
            var dbConsumable = await _context.Consumables.FirstOrDefaultAsync(p => p.Id == consumable.Id);
            if (dbConsumable == null)
            {
                return NotFound("""Categoria nu exista.""");
            }

            dbConsumable.Name = consumable.Name;
            //dbConsumable.isDeleted = 1;


            await _context.SaveChangesAsync();

            return Ok(dbConsumable);
        }
    }
}
