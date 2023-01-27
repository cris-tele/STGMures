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
            var response = await _http.PostAsJsonAsync("api/DiagCategory", DiagnosticCategory);
            await LoadDiagnosticCategoriesAsync();
        }

        public async Task DeleteDiagnosticCategory(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/DiagCategory/{id}");
            await LoadDiagnosticCategoriesAsync();
        }

        public async Task LoadDiagnosticCategoriesAsync() //GETALL
        {
            Categories = await _http.GetFromJsonAsync<List<DiagnosticCategory>>("api/DiagCategory");
        }

        public async Task<DiagnosticCategory> GetDiagnosticCategory(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<DiagnosticCategory>>("api/DiagCategory");
            return response.Data;
        }

        public async Task UpdateDiagnosticCategory(DiagnosticCategory DiagnosticCategory) // PUT
        {
            await _http.PutAsJsonAsync("api/DiagCategory", DiagnosticCategory);
            await LoadDiagnosticCategoriesAsync();
        }

    }
}
