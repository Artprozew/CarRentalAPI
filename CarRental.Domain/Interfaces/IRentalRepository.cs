using CarRental.Domain.Entities;
using CarRental.Domain.Pagination;

namespace CarRental.Domain.Interfaces
{
    public interface IRentalRepository
    {
        Task<Rental> CreateAsync(Rental rental);
        Task<Rental> UpdateAsync(Rental rental);
        Task<Rental?> DeleteAsync(int id);
        Task<Rental?> GetAsync(int id);
        Task<Rental?> GetAsync(uint id);
        Task<PagedList<Rental>> GetAllAsync(int pageNumber, int pageSize);
        Task<bool> SaveAllAsync();
        Task<bool> IsAvailableAsync(uint id);
    }
}
