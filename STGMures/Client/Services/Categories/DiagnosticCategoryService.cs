using StgMures.Shared;
using System.Net.Http.Json;

using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public class DiagnosticCategoryService : IDiagnosticCategoryService
    {
        private readonly HttpClient _http;

        public List<DiagnosticCategory> Categories { get; set; } = new List<DiagnosticCategory>();

        public DiagnosticCategoryService(HttpClient http)
        {
            _http = http;
        }


        public async Task AddDiagnosticCategory(DiagnosticCategory DiagnosticCategory) // POST
        {
            var response = await _http.PostAsJsonAsync("api/DCategory", DiagnosticCategory);
            await LoadDiagnosticCategoriesAsync();
        }

        public async Task DeleteDiagnosticCategory(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/DCategory/{id}");
            await LoadDiagnosticCategoriesAsync();
        }

        public async Task LoadDiagnosticCategoriesAsync() //GETALL
        {
            Categories = await _http.GetFromJsonAsync<List<DiagnosticCategory>>("api/DCategory");
        }

        public async Task<DiagnosticCategory> GetDiagnosticCategory(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<DiagnosticCategory>>("api/DCategory");
            return response.Data;
        }

        public async Task UpdateDiagnosticCategory(DiagnosticCategory DiagnosticCategory) // PUT
        {
            await _http.PutAsJsonAsync("api/DCategory", DiagnosticCategory);
            await LoadDiagnosticCategoriesAsync();
        }

    }
}
