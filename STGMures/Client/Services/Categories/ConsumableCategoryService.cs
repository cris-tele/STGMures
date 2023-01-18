using StgMures.Shared.DbModels;
using StgMures.Shared;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class ConsumableCategoryService : IConsumableCategoryService
    {
        private readonly HttpClient _http;

        public List<ConsumableCategory> Categories { get; set; } = new List<ConsumableCategory>();

        public ConsumableCategoryService(HttpClient http)
        {
            _http = http;
        }


        public async Task AddConsumableCategory(ConsumableCategory consumableCategory) // POST
        {
            var response = await _http.PostAsJsonAsync("api/CCategory", consumableCategory);
            await LoadConsumableCategoriesAsync();
        }

        public async Task DeleteConsumableCategory(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/CCategory/{id}");
            await LoadConsumableCategoriesAsync();
        }

        public async Task LoadConsumableCategoriesAsync() //GETALL
        {
            Categories = await _http.GetFromJsonAsync<List<ConsumableCategory>>("api/CCategory");
        }

        public async Task<ConsumableCategory> GetConsumableCategory(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<ConsumableCategory>>("api/CCategory");
            return response.Data;
        }

        public async Task UpdateConsumableCategory(ConsumableCategory ConsumableCategory) // PUT
        {
            await _http.PutAsJsonAsync("api/CCategory", ConsumableCategory);
            await LoadConsumableCategoriesAsync();
        }

    }
}
