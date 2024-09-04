using CarRental.Domain.Entities;

namespace CarRental.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<User?> DeleteAsync(int id);
        Task<User?> GetAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
    }
}
