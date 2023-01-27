using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface ITreatmentTypeService
    {
        List<Treatment> Types { get; set; }
        Task<Treatment> GetTreatment(int id);
        Task LoadTreatmentsAsync(); //getall
        Task AddTreatment(Treatment treatment);
        Task UpdateTreatment(Treatment treatment);
        Task DeleteTreatment(int id);   // delete dupa id

    }
}
