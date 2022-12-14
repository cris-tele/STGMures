namespace StgMures.Server.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<string>> Register(Medic user, string password);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<bool> UserExists(string email);
    }
}
