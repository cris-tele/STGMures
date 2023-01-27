using StgMures.Shared.DbModels;

namespace StgMures.Client.Services
{
    public interface IConsumableTypeService
    {
        List<Consumable> Types { get; set; }
        Task<Consumable> GetConsumable(int id);
        Task LoadConsumablesAsync(); //getall
        Task AddConsumable(Consumable consumable);
        Task UpdateConsumable(Consumable consumable);
        Task DeleteConsumable(int id);   // delete dupa id

    }
}
