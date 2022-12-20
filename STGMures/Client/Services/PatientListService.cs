using Blazored.Toast.Services;
using Microsoft.EntityFrameworkCore;
using StgMures.Shared.DbModels;
using StgMures.Client;
using System.Net.Http;

using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;

namespace StgMures.Client.Services
{
    public class PatientListService : IPatientListService
    {
        private readonly HttpClient _http;

        public PatientListService(/*IToastService toastService,*/ HttpClient http)
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
                Patients = await _http.GetFromJsonAsync<IList<Patient>>("/PatientsList");
            }
            return Patients;
        }
    }
}
