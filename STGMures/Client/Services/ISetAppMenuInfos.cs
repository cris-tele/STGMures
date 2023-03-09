using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface ISetAppMenuInfos
    {
        event Action OnChange;

        public string   PageTitle { get; set; } 
        public string   MedicName { get; set; } 
        public string   PatientName { get; set; } 
        public Patient  SelectedPatient { get; set; } 
        public Medic    LoggedMedic { get; set; } 

        public void SetPageTitle(string title);
        public void SetLoggedMedicName(string loggedMedic);
        public void SetPatientName(string selectedPatient);

    }
}
