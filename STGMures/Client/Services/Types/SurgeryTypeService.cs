using StgMures.Shared.DbModels;
using StgMures.Shared;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class SurgeryTypeService :ISurgeryTypeService
    {
        private readonly HttpClient _http;

        public List<Surgery> Types { get; set; } = new List<Surgery>();

        public SurgeryTypeService(HttpClient http)
        {
            _http = http;
        }


        public async Task AddSurgery(Surgery Surgery) // POST
        {
            var response = await _http.PostAsJsonAsync("api/SurgeryType", Surgery);
            await LoadSurgeryTypesAsync();
        }

        public async Task DeleteSurgery(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/SurgeryType/{id}");
            await LoadSurgeryTypesAsync();
        }

        public async Task LoadSurgeryTypesAsync() //GETALL
        {
            Types = await _http.GetFromJsonAsync<List<Surgery>>("api/SurgeryType");
        }

        public async Task<Surgery> GetSurgery(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<Surgery>>("api/SurgeryType");
            return response.Data;
        }

        public async Task UpdateSurgery(Surgery Surgery) // PUT
        {
            await _http.PutAsJsonAsync("api/SurgeryType", Surgery);
            await LoadSurgeryTypesAsync();
        }

    }
}
