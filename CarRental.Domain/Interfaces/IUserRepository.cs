using CarRental.Domain.Entities;
using CarRental.Domain.Pagination;

namespace CarRental.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User?> DeleteAsync(uint id);
        Task<User?> GetAsync(int id);
        Task<PagedList<User>> GetAllAsync(int pageNumber, int pageSize);
        Task<bool> RegisteredUserExistsAsync();
    }
}
