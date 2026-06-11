using CarRental.Domain.Entities;
using CarRental.Domain.Pagination;

namespace CarRental.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer);
        Task<Customer?> DeleteAsync(uint id);
        Task<Customer?> GetAsync(int id);
        Task<PagedList<Customer>> GetAllAsync(int pageNumber, int pageSize);
        Task<bool> SaveAllAsync();
    }
}
