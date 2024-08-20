using CarRental.Domain.Entities;

namespace CarRental.API.Interfaces
{
    public interface ICustomerRepository
    {
        void Create(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task<Customer> SelectByPrimaryKey(int id);
        Task<IEnumerable<Customer>> GetAll();
        Task<bool> SaveAllAsync();
    }
}
