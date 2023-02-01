using StgMures.Shared.DbModels;
using StgMures.Shared;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class PatientSurgeryService : IPatientSurgeryService
    {

        private readonly HttpClient _http;

        public List<PatientSurgery> PatientSurgeries { get; set; } = new List<PatientSurgery>();
        public PatientSurgeryService(HttpClient http)
        {
            _http = http;
        }

        public async Task AddPatientSurgery(PatientSurgery surgery) // POST
        {
            await _http.PostAsJsonAsync("api/PatientsSurgeries", surgery);
            await LoadPatientSurgeriesAsync();
        }

        public async Task DeletePatientSurgery(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/PatientsSurgeries/{id}");
            await LoadPatientSurgeriesAsync();
        }

        public async Task<PatientSurgery> GetPatientSurgery(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<PatientSurgery>>($"api/PatientsSurgeries/{id}");
            return response.Data;
        }

        public async Task LoadPatientSurgeriesAsync()
        {
            PatientSurgeries = await _http.GetFromJsonAsync<List<PatientSurgery>>("api/PatientsSurgeries");
        }


        public async Task UpdatePatientSurgery(PatientSurgery PatientSurgery) // PUT
        {
            await _http.PutAsJsonAsync("api/PatientsSurgeries", PatientSurgery);
            await LoadPatientSurgeriesAsync();
        }

    }
}
