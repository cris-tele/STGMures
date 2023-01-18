using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface IConsumableCategoryService
    {
        List<ConsumableCategory> Categories { get; set; }
        Task<ConsumableCategory> GetConsumableCategory(int id);
        Task LoadConsumableCategoriesAsync(); //getall
        Task AddConsumableCategory(ConsumableCategory consumableCategory);
        Task UpdateConsumableCategory(ConsumableCategory consumableCategory);
        Task DeleteConsumableCategory(int id);   // delete dupa id

    }
}
