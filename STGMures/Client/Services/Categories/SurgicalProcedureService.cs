using StgMures.Shared.DbModels;
using StgMures.Shared;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class SurgicalProcedureService: ISurgicalProcedureService
    {
        private readonly HttpClient _http;

        public List<SurgicalProcedure> Categories { get; set; } = new List<SurgicalProcedure>();

        public SurgicalProcedureService(HttpClient http)
        {
            _http = http;
        }


        public async Task AddSurgicalProcedure(SurgicalProcedure SurgicalProcedure) // POST
        {
            var response = await _http.PostAsJsonAsync("api/SProcCategory", SurgicalProcedure);
            await LoadSurgicalProceduresAsync();
        }

        public async Task DeleteSurgicalProcedure(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/SProcCategory/{id}");
            await LoadSurgicalProceduresAsync();
        }

        public async Task LoadSurgicalProceduresAsync() //GETALL
        {
            Categories = await _http.GetFromJsonAsync<List<SurgicalProcedure>>("api/SProcCategory");
        }

        public async Task<SurgicalProcedure> GetSurgicalProcedure(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<SurgicalProcedure>>("api/SProcCategory");
            return response.Data;
        }

        public async Task UpdateSurgicalProcedure(SurgicalProcedure SurgicalProcedure) // PUT
        {
            await _http.PutAsJsonAsync("api/SProcCategory", SurgicalProcedure);
            await LoadSurgicalProceduresAsync();
        }

    }
}
