using Microsoft.EntityFrameworkCore;

using System.Security.Claims;

namespace StgMures.Server.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly StgMuresContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UtilityService(StgMuresContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Medic> GetMedic()
        {
            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _context.Medics.FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }
    }
}
