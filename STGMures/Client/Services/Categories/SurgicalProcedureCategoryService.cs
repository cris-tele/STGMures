using StgMures.Shared.DbModels;
using StgMures.Shared;
using System.Net.Http.Json;

namespace StgMures.Client.Services.Categories
{
    public class SurgicalProcedureCategoryService: ISurgicalProcedureCategoryService
    {
        private readonly HttpClient _http;

        public List<SurgicalProcedure> Categories { get; set; } = new List<SurgicalProcedure>();

        public SurgicalProcedureCategoryService(HttpClient http)
        {
            _http = http;
        }


        public async Task AddSurgicalProcedure(SurgicalProcedure SurgicalProcedure) // POST
        {
            var response = await _http.PostAsJsonAsync("api/SpCategory", SurgicalProcedure);
            await LoadSurgicalProceduresAsync();
        }

        public async Task DeleteSurgicalProcedure(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/SpCategory/{id}");
            await LoadSurgicalProceduresAsync();
        }

        public async Task LoadSurgicalProceduresAsync() //GETALL
        {
            Categories = await _http.GetFromJsonAsync<List<SurgicalProcedure>>("api/SpCategory");
        }

        public async Task<SurgicalProcedure> GetSurgicalProcedure(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<SurgicalProcedure>>("api/SpCategory");
            return response.Data;
        }

        public async Task UpdateSurgicalProcedure(SurgicalProcedure SurgicalProcedure) // PUT
        {
            await _http.PutAsJsonAsync("api/SpCategory", SurgicalProcedure);
            await LoadSurgicalProceduresAsync();
        }

    }
}
