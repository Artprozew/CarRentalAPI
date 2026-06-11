using CarRental.Domain.Entities;
using CarRental.Domain.Pagination;

namespace CarRental.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<Car> CreateAsync(Car car);
        Task<Car> UpdateAsync(Car car);
        Task<Car?> DeleteAsync(uint id);
        Task<Car?> GetAsync(int id);
        Task<PagedList<Car>> GetAllAsync(int pageNumber, int pageSize);
        Task<bool> SaveAllAsync();
    }
}
