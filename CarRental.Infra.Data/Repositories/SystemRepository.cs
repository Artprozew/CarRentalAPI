using CarRental.Domain.Interfaces;
using CarRental.Domain.SystemModels;
using CarRental.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infra.Data.Repositories
{
    public class SystemRepository : ISystemRepository
    {
        private readonly ApplicationDbContext _context;

        public SystemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ItemsQuantity> GetItemsQuantityAsync()
        {
            return new ItemsQuantity
            {
                CarQuantity = (uint)await _context.Car.CountAsync(),
                CustomerQuantity = (uint)await _context.Customer.CountAsync(),
                RentalQuantity = (uint)await _context.Rental.CountAsync()
            };
        }
    }
}
