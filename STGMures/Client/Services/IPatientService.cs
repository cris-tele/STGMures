using Blazored.Toast.Services;
using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface IPatientService
    {
        IList<Patient> GetPatients { get; set; }
        IList<Medic>    GetMyMedics { get; set; }

        Task AddPatient(int id, Patient patient);
        Task DeletePatient(int id);
        Task<Patient> GetPatient(int id);
        Task<IList<Patient>> GetAllPatients();
        Task<Patient> UpdatePatient(Patient patient);


    }
}
