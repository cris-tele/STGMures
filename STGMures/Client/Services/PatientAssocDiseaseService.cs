using StgMures.Shared.DbModels;
using StgMures.Shared;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class PatientAssocDiseaseService : IPatientAssocDiseaseService
    {
        private readonly HttpClient _http;
        public PatientAssocDiseaseService(HttpClient http)
        {
            _http = http;
        }

        public List<PatientAssocDisease> PatientAssocDiseases { get; set; } = new ();

        public async Task AddPatientAssocDisease(PatientAssocDisease _patient) // POST
        {
            await _http.PostAsJsonAsync("api/PatientAssoc", _patient);
            await LoadPatientAssocDiseasesAsync();
        }

        public async Task DeletePatientAssocDisease(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/PatientAssoc/{id}");
            await LoadPatientAssocDiseasesAsync();
        }

        public async Task<PatientAssocDisease> GetPatientAssocDisease(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<PatientAssocDisease>>("api/PatientAssoc");
            return response.Data;
        }

        public async Task LoadPatientAssocDiseasesAsync()
        {
            PatientAssocDiseases = await _http.GetFromJsonAsync<List<PatientAssocDisease>>("api/PatientAssoc");
        }


        public async Task UpdatePatientAssocDisease(PatientAssocDisease Patient) // PUT
        {
            await _http.PutAsJsonAsync("api/PatientAssoc", Patient);
            await LoadPatientAssocDiseasesAsync();
        }

    }
}
