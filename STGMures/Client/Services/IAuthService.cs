using StgMures.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StgMures.Shared.SesionModels;
using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin request);

    }
}
