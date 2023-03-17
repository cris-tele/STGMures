using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface ISurgicalCategoryService
    {
        List<SurgicalCategory> SurgicalCategories { get; set; }
        Task<SurgicalCategory> GetSurgicalCategory(int id);
        Task LoadSurgicalCategoriesAsync(); //getall
        Task AddSurgicalCategory(SurgicalCategory surgicalProcedure);
        Task UpdateSurgicalCategory(SurgicalCategory surgicalProcedure);
        Task DeleteSurgicalCategory(int id);   // delete dupa id
    }
}

