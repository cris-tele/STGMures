using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public class SetAppMenuInfos : ISetAppMenuInfos
    {
        public event Action? OnChange;
        public string   PageTitle { get ; set ; } = string.Empty;
        public string   MedicName { get; set; } = string.Empty;
        public string   PatientName { get; set; } = string.Empty;

        public Patient  SelectedPatient { get; set; } = new();

        public Medic    LoggedMedic { get; set; } = new();

        public void SetLoggedMedicName(string loggedMedic)
        {
            if (string.IsNullOrEmpty(loggedMedic))
                MedicName = " ";
            else
                MedicName = loggedMedic;
            CurrentSelectionChange();
        }

        public void SetPageTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                PageTitle = "Err setting page title";
            else 
                PageTitle = title;
            CurrentSelectionChange();
        }

        public void SetPatientName(string selectedPatient)
        {
            if (string.IsNullOrEmpty(selectedPatient))
                PatientName = "Unknown patient";
            else
                PatientName = selectedPatient;
            CurrentSelectionChange();
        }

        void CurrentSelectionChange() => OnChange?.Invoke();
    }
}
