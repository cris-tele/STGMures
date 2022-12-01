using Blazored.Toast.Services;
using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public class PatientService : IPatientService
    {
        private readonly IToastService _toastService;
        private readonly HttpClient _http;

        public PatientService(IToastService toastService, HttpClient http)
        {
            _toastService = toastService;
            _http = http;
        }
        IList<Patient> IPatientService.GetPatients { get; set; } = new List<Patient>();
        IList<Medic> IPatientService.GetMyMedics { get ; set ; } = new List<Medic>();   // de ce medic/medici apartine pacientul

        Task IPatientService.AddPatient(int id, Patient patient)
        {
            throw new NotImplementedException();
        }

        Task IPatientService.DeletePatient(int id)
        {
            throw new NotImplementedException();
        }

        Task<IList<Patient>> IPatientService.GetAllPatients()
        {
            throw new NotImplementedException();
        }

        Task<Patient> IPatientService.GetPatient(int id)
        {
            throw new NotImplementedException();
        }

        Task<Patient> IPatientService.UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }
    }
}
