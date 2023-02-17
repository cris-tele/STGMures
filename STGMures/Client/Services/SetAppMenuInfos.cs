namespace StgMures.Client.Services
{
    public class SetAppMenuInfos : ISetAppMenuInfos
    {
        public event Action? OnChange;
        public string PageTitle { get ; set ; } = string.Empty;
        public string LoggedMedic { get; set; } = string.Empty;
        public string SelectedPatient { get; set; } = string.Empty;
        public bool DisabledState { get; set; } = false;

        public void SetLoggedMedic(string loggedMedic)
        {
            if (string.IsNullOrEmpty(loggedMedic))
                LoggedMedic = " --- ";
            else
            LoggedMedic = loggedMedic;
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

        public void SetSelectedPatient(string selectedPatient)
        {
            if (string.IsNullOrEmpty(selectedPatient))
                SelectedPatient = "Unknoun patient";
            else 
                SelectedPatient = selectedPatient;
            CurrentSelectionChange();
        }

        public  void SetDisabledState(bool disabled)
        {
            DisabledState = disabled;
            CurrentSelectionChange();
        }


        void CurrentSelectionChange() => OnChange?.Invoke();
    }
}
