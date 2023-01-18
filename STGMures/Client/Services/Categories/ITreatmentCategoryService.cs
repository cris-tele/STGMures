using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface ITreatmentCategoryService 
    {
        List<TreatmentCategory> Categories { get; set; }
        Task<TreatmentCategory> GetTreatmentCategory(int id);
        Task LoadTreatmentCategoriesAsync(); //getall
        Task /*<TreatmentCategory>*/ AddTreatmentCategory(TreatmentCategory treatmentCategory);
        Task UpdateTreatmentCategory(TreatmentCategory treatmentCategory);   
        Task DeleteTreatmentCategory(int id);   // delete dupa id
    
    }
}
