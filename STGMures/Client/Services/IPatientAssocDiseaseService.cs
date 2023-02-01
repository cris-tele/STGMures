using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface IPatientAssocDiseaseService
    {
        List<PatientAssocDisease> PatientAssocDiseases { get; set; }
        Task<PatientAssocDisease> GetPatientAssocDisease(int id);
        Task LoadPatientAssocDiseasesAsync(); 
        Task AddPatientAssocDisease(PatientAssocDisease Surgery);
        Task UpdatePatientAssocDisease(PatientAssocDisease Surgery);
        Task DeletePatientAssocDisease(int id);   

    }
}
