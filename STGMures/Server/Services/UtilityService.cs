using StgMures.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using StgMures.Shared.DbModels;
using StgMures.Shared;

using StgMures.Server.Data;

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

        public async Task<Medic> GetUser()
        {
            var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _context.Medics.FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }
    }
}
