using CarRental.API.Interfaces;
using CarRental.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRental.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ControlCarRentalContext _controlCarRentalContext;

        public CustomerRepository(ControlCarRentalContext context)
        {
            _controlCarRentalContext = context;
        }

        public void Delete(Customer customer)
        {
            _controlCarRentalContext.Customers.Remove(customer);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _controlCarRentalContext.Customers.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _controlCarRentalContext.SaveChangesAsync() > 0;
        }

        public async Task<Customer> SelectByPrimaryKey(int id)
        {
            return await _controlCarRentalContext.Customers.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
        }

        public void Create(Customer customer)
        {
            _controlCarRentalContext.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _controlCarRentalContext.Entry(customer).State = EntityState.Modified;
        }
    }
}
