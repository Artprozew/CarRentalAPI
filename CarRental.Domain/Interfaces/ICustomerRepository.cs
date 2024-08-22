using CarRental.Domain.Entities;

namespace CarRental.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<Customer?> DeleteAsync(int id);
        Task<Customer?> GetAsync(int id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<bool> SaveAllAsync();
    }
}
