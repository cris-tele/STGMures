using StgMures.Shared.DbModels;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class PatientListService : IPatientListService
    {
        private readonly HttpClient _http;

        public PatientListService(HttpClient http)
        {
            _http = http;
        }
        public IList<Patient> Patients { get; set; } = new List<Patient>();
        IList<Medic> IPatientListService.GetMyMedics { get ; set ; } = new List<Medic>();   // de ce medic/medici apartine pacientul

        Task IPatientListService.AddPatient(int id, Patient patient)
        {
            throw new NotImplementedException();
        }

        Task IPatientListService.DeletePatient(int id)
        {
            throw new NotImplementedException();
        }

        Task<Patient> IPatientListService.GetPatient(int id)
        {
            throw new NotImplementedException();
        }

        Task<Patient> IPatientListService.UpdatePatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Patient>> GetAllPatients()
        {
            if (Patients.Count == 0)
            {
                Patients = (await _http.GetFromJsonAsync<IList<Patient>>("/PatientsList"))!;
            }
            return Patients;
        }
    }
}
