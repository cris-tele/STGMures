using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface IDiagnosticCategoryService
    {
        List<DiagnosticCategory> Categories { get; set; }
        Task<DiagnosticCategory> GetDiagnosticCategory(int id);
        Task LoadDiagnosticCategoriesAsync(); //getall
        Task /*<DiagnosticCategory>*/ AddDiagnosticCategory(DiagnosticCategory diagnosticCategory);
        Task UpdateDiagnosticCategory(DiagnosticCategory diagnosticCategory);
        Task DeleteDiagnosticCategory(int id);   // delete dupa id

    }
}
