using CarRental.Domain.SystemModels;

namespace CarRental.Domain.Interfaces
{
    public interface ISystemRepository
    {
        Task<ItemsQuantity> GetItemsQuantityAsync();
    }
}
