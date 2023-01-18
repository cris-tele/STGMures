using StgMures.Shared;
using System.Net.Http.Json;
using System.Net;
using MudBlazor;

using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public class TreatmentCategoryService : ITreatmentCategoryService
    {
        private readonly HttpClient _http;

        public List<TreatmentCategory> Categories { get; set; } = new List<TreatmentCategory>();

        public TreatmentCategoryService(HttpClient http)
        {
            _http = http;
        }


        public async Task AddTreatmentCategory(TreatmentCategory treatmentCategory) // POST
        {
            var response = await _http.PostAsJsonAsync("api/TCategory", treatmentCategory);
            await LoadTreatmentCategoriesAsync();
        }

        public async Task DeleteTreatmentCategory(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/TCategory/{id}");
            await LoadTreatmentCategoriesAsync();
        }

        public async Task LoadTreatmentCategoriesAsync() //GETALL
        {
            Categories = await _http.GetFromJsonAsync<List<TreatmentCategory>>("api/TCategory");
        }

        public async Task<TreatmentCategory> GetTreatmentCategory(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<TreatmentCategory>>("api/TCategory");
            return response.Data;
        }

        public async Task UpdateTreatmentCategory(TreatmentCategory treatmentCategory) // PUT
        {
            await _http.PutAsJsonAsync("api/TCategory", treatmentCategory);
            await LoadTreatmentCategoriesAsync();
        }
    }
}
