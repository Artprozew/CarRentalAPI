using CarRental.Application.DTOs;

namespace CarRental.Application.Interfaces
{
    public interface ISystemService
    {
        public Task<ItemsQuantityDTO> GetItemsQuantityAsync();
    }
}
