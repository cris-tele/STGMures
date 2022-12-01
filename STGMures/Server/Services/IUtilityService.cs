using StgMures.Shared.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StgMures.Server.Services
{
    public interface IUtilityService
    {
        Task<Medic> GetUser();
    }
}
