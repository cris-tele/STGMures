using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface ISurgicalProcedureCategoryService
    {
        List<SurgicalProcedure> Categories { get; set; }
        Task<SurgicalProcedure> GetSurgicalProcedure(int id);
        Task LoadSurgicalProceduresAsync(); //getall
        Task AddSurgicalProcedure(SurgicalProcedure SurgicalProcedure);
        Task UpdateSurgicalProcedure(SurgicalProcedure SurgicalProcedure);
        Task DeleteSurgicalProcedure(int id);   // delete dupa id
    }
}

