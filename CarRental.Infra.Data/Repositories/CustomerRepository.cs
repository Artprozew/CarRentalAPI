using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infra.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer?> DeleteAsync(int id)
        {
            Customer? customer = await _context.Customer.FindAsync(id);

            if (customer != null)
            {
                _context.Customer.Remove(customer);
                await _context.SaveChangesAsync();
            }

            return customer;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            _context.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            return await _context.Customer.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Customer?> GetAsync(int id)
        {
            return await _context.Customer.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
        }
    }
}
