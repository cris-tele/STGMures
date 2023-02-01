using StgMures.Shared.DbModels;
using StgMures.Shared;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class PatientFileService :IPatientFileService
    {
        private readonly HttpClient _http;

        public List<PatientFile> PatientFiles { get; set; } = new List<PatientFile>();
        public PatientFileService(HttpClient http)
        {
            _http = http;
        }

        public async Task AddPatientFile(PatientFile _patient) // POST
        {
            await _http.PostAsJsonAsync("api/PatientsFiles", _patient);
            await LoadPatientFilesAsync();
        }

        public async Task DeletePatientFile(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/PatientsFiles/{id}");
            await LoadPatientFilesAsync();
        }

        public async Task<PatientFile> GetPatientFile(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<PatientFile>>($"api/PatientsFiles/{id}");
            return response.Data;
        }

        public async Task LoadPatientFilesAsync()
        {
            PatientFiles = await _http.GetFromJsonAsync<List<PatientFile>>("api/PatientsFiles");
        }


        public async Task UpdatePatientFile (PatientFile PatientFile) // PUT
        {
            await _http.PutAsJsonAsync("api/PatientsFiles", PatientFile);
            await LoadPatientFilesAsync();
        }
    }
}
