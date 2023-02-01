using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface IPatientFileService
    {
        List<PatientFile> PatientFiles { get; set; }    // usually one, but a pacient usually has more that one hospitalization

        Task<PatientFile> GetPatientFile(int id);
        Task LoadPatientFilesAsync();
        Task AddPatientFile(PatientFile _patient);
        Task UpdatePatientFile(PatientFile _patient);
        Task DeletePatientFile(int id);

    }
}
