using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface ISurgeryTypeService
    {
        List<Surgery> Types{ get; set; }
        Task<Surgery> GetSurgery(int id);
        Task LoadSurgeryTypesAsync(); //getall
        Task AddSurgery(Surgery Surgery);
        Task UpdateSurgery(Surgery Surgery);
        Task DeleteSurgery(int id);   // delete dupa id

    }
}
