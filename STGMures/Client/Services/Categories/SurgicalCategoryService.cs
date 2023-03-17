using StgMures.Shared.DbModels;
using StgMures.Shared;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class SurgicalCategoryService: ISurgicalCategoryService
    {
        private readonly HttpClient _http;

        public List<SurgicalCategory> SurgicalCategories { get; set; } = new List<SurgicalCategory>();

        public SurgicalCategoryService(HttpClient http)
        {
            _http = http;
        }


        public async Task AddSurgicalCategory(SurgicalCategory SurgicalCategory) // POST
        {
            var response = await _http.PostAsJsonAsync("api/SProcCategory", SurgicalCategory);
            await LoadSurgicalCategoriesAsync();
        }

        public async Task DeleteSurgicalCategory(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/SProcCategory/{id}");
            await LoadSurgicalCategoriesAsync();
        }

        public async Task LoadSurgicalCategoriesAsync() //GETALL
        {
            SurgicalCategories = await _http.GetFromJsonAsync<List<SurgicalCategory>>("api/SProcCategory");
        }

        public async Task<SurgicalCategory> GetSurgicalCategory(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<SurgicalCategory>>($"api/SProcCategory/{id}");
            return response.Data;
        }

        public async Task UpdateSurgicalCategory(SurgicalCategory surgicalProcedure) // PUT
        {
            await _http.PutAsJsonAsync($"api/SProcCategory/{surgicalProcedure.Id}", surgicalProcedure);
            await LoadSurgicalCategoriesAsync();
        }

    }
}
