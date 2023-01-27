using StgMures.Shared.DbModels;
using StgMures.Shared;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class DiagnosticTypeService :IDiagnosticTypeService
    {
        private readonly HttpClient _http;

        public List<Diagnostic> Types { get; set; } = new List<Diagnostic>();

        public DiagnosticTypeService(HttpClient http)
        {
            _http = http;
        }


        public async Task AddDiagnostic(Diagnostic Diagnostic) // POST
        {
            var response = await _http.PostAsJsonAsync("api/DiagType", Diagnostic);
            await LoadDiagnosticsAsync();
        }

        public async Task DeleteDiagnostic(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/DiagType/{id}");
            await LoadDiagnosticsAsync();
        }

        public async Task LoadDiagnosticsAsync() //GETALL
        {
            Types = await _http.GetFromJsonAsync<List<Diagnostic>>("api/DiagType");
        }

        public async Task<Diagnostic> GetDiagnostic(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<Diagnostic>>("api/DiagType");
            return response.Data;
        }

        public async Task UpdateDiagnostic(Diagnostic Diagnostic) // PUT
        {
            await _http.PutAsJsonAsync("api/DiagType", Diagnostic);
            await LoadDiagnosticsAsync();
        }

    }

}

