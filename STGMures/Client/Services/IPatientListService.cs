using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface IPatientListService
    {
        IList<Patient> Patients { get; set; }
        IList<Medic>    GetMyMedics { get; set; }

        Task AddPatient(int id, Patient patient);
        Task DeletePatient(int id);
        Task<Patient> GetPatient(int id);
        Task<IList<Patient>> GetAllPatients();
        Task<Patient> UpdatePatient(Patient patient);


    }
}
