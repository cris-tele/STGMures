using StgMures.Shared.DbModels;
using StgMures.Shared;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class ConsumableTypeService :IConsumableTypeService
    {
        private readonly HttpClient _http;

        public List<Consumable> Types { get; set; } = new List<Consumable>();

        public ConsumableTypeService(HttpClient http)
        {
            _http = http;
        }


        public async Task AddConsumable(Consumable consumable) // POST
        {
            var response = await _http.PostAsJsonAsync("api/ConsType", consumable);
            await LoadConsumablesAsync();
        }

        public async Task DeleteConsumable(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/ConsType/{id}");
            await LoadConsumablesAsync();
        }

        public async Task LoadConsumablesAsync() //GETALL
        {
            Types = await _http.GetFromJsonAsync<List<Consumable>>("api/ConsType");
        }

        public async Task<Consumable> GetConsumable(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<Consumable>>($"api/ConsType/{id}");
            return response.Data;
        }

        public async Task UpdateConsumable(Consumable consumable) // PUT
        {
            await _http.PutAsJsonAsync($"api/ConsType/{consumable.Id}", consumable);
            await LoadConsumablesAsync();
        }

    }
}
