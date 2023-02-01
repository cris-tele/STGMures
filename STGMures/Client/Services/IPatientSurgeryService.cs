using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface IPatientSurgeryService
    {
        List<PatientSurgery> PatientSurgeries { get; set; }    // usually one, but ....

        Task<PatientSurgery> GetPatientSurgery(int id);
        Task LoadPatientSurgeriesAsync();
        Task AddPatientSurgery(PatientSurgery surgery);
        Task UpdatePatientSurgery(PatientSurgery surgery);
        Task DeletePatientSurgery(int id);

    }
}
