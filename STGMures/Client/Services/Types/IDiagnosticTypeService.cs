using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface IDiagnosticTypeService
    {
        List<Diagnostic> Types { get; set; }
        Task<Diagnostic> GetDiagnostic(int id);
        Task LoadDiagnosticsAsync(); //getall
        Task AddDiagnostic(Diagnostic diagnostic);
        Task UpdateDiagnostic(Diagnostic diagnostic);
        Task DeleteDiagnostic(int id);   // delete dupa id

    }
}
