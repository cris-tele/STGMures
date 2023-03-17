using StgMures.Shared.DbModels;
using StgMures.Shared;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class TreatmentTypeService : ITreatmentTypeService
    {
        private readonly HttpClient _http;

        public List<Treatment> Types { get; set; } = new List<Treatment>();

        public TreatmentTypeService(HttpClient http)
        {
            _http = http;
        }


        public async Task AddTreatment(Treatment treatment) // POST
        {
            if (treatment == null)
                return;
            if (treatment.Id != 0)
                treatment.Id = 0;   //identity

            var response = await _http.PostAsJsonAsync("api/TreatType", treatment);
            await LoadTreatmentsAsync();
        }

        public async Task DeleteTreatment(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/TreatType/{id}");
            await LoadTreatmentsAsync();
        }

        public async Task LoadTreatmentsAsync() //GETALL
        {
            Types = await _http.GetFromJsonAsync<List<Treatment>>("api/TreatType");
        }

        public async Task<Treatment> GetTreatment(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<Treatment>>("api/TreatType");
            return response.Data;
        }

        public async Task UpdateTreatment(Treatment treatment) // PUT
        {
            await _http.PutAsJsonAsync("api/TreatType", treatment);
            await LoadTreatmentsAsync();
        }
    }
}
