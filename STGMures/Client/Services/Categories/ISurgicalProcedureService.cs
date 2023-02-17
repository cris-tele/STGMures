using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface ISurgicalProcedureService
    {
        List<SurgicalProcedure> SurgicalProcedures { get; set; }
        Task<SurgicalProcedure> GetSurgicalProcedure(int id);
        Task LoadSurgicalProceduresAsync(); //getall
        Task AddSurgicalProcedure(SurgicalProcedure surgicalProcedure);
        Task UpdateSurgicalProcedure(SurgicalProcedure surgicalProcedure);
        Task DeleteSurgicalProcedure(int id);   // delete dupa id
    }
}

