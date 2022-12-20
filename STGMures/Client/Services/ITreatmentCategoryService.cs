using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface ITreatmentCategoryService 
    { 
    IList<TreatmentCategoryService> TreatmentCategoryes { get; set; }
    Task<TreatmentCategoryService> GetTreatmentCategory(int id);
    Task<TreatmentCategoryService> GetTreatmentCategoryes();

    Task AddTreatmentCategory(int id, TreatmentCategoryService treatmentCategory);
    Task DeleteTreatmentCategory(int id);
    Task<Patient> UpdateTreatmentCategory(TreatmentCategoryService treatmentCategory);
    
    }
}
