﻿using StgMures.Shared;
using StgMures.Shared.DbModels;
using System.Net.Http.Json;

namespace StgMures.Client.Services
{
    public class PatientListService : IPatientListService
    {
        private readonly HttpClient _http;

        public List<Patient> Patients { get; set; } = new List<Patient>();
        //        public List<Medic> GetMyMedics { get ; set ; } = new List<Medic>();   // de ce medic/medici apartine pacientul
        public PatientListService(HttpClient http)
        {
            _http = http;
        }
  
        public async Task AddPatient(Patient _patient) // POST
        {
            await _http.PostAsJsonAsync("api/PatientsList", _patient);
            await LoadPatientsAsync();
        }

        public async Task DeletePatient(int id)   //DELETE
        {
            await _http.DeleteAsync($"api/PatientsList/{id}");
            await LoadPatientsAsync();
        }

        public async Task<Patient> GetPatient(int id) //GET
        {
            var response = await _http
                .GetFromJsonAsync<ServiceResponse<Patient>>($"api/PatientsList/{id}");
            return response.Data;
        }
        
        public async Task LoadPatientsAsync()
        {
            Patients = await _http.GetFromJsonAsync<List<Patient>>("api/PatientsList");
        }

        
        public async Task UpdatePatient(Patient Patient) // PUT
        {
            await _http.PutAsJsonAsync("api/PatientsList", Patient);
            await LoadPatientsAsync();
        }

    }
}
