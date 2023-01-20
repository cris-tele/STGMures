using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface IPatientListService
    {
        List<Patient> Patients { get; set; }
        // List<Medic>    GetMyMedics { get; set; }

        Task<Patient> GetPatient(int id);
        Task LoadPatientsAsync();
        Task AddPatient(Patient patient);
        Task UpdatePatient(Patient patient);
        Task DeletePatient(int id);
    }
}
