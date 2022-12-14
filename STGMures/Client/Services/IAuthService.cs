using StgMures.Shared;
using StgMures.Shared.Dto;

namespace StgMures.Client.Services
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin request);

    }
}
