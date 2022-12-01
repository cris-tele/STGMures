using StgMures.Shared;
using StgMures.Shared.SesionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StgMures.Shared.DbModels;

namespace StgMures.Server.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<string>> Register(Medic user, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<bool> UserExists(string email);
    }
}
