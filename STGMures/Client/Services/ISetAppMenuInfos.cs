namespace StgMures.Client.Services
{
    public interface ISetAppMenuInfos
    {
        event Action OnChange;
        string PageTitle { get; set; }
        string LoggedMedic { get; set; }

        string SelectedPatient { get; set; }

        void SetPageTitle(string title);
        void SetLoggedMedic(string loggedMedic);    
        void SetSelectedPatient(string selectedPatient);    


    }
}
