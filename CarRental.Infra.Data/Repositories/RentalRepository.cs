using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Pagination;
using CarRental.Infra.Data.Context;
using CarRental.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infra.Data.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ApplicationDbContext _context;

        public RentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Rental> CreateAsync(Rental rental)
        {
            _context.Rental.Add(rental);
            await _context.SaveChangesAsync();
            return rental;
        }

        public async Task<Rental?> DeleteAsync(int id)
        {
            Rental? rental = await _context.Rental.FindAsync(id);

            if (rental != null)
            {
                _context.Rental.Remove(rental);
                await _context.SaveChangesAsync();
            }

            return rental;
        }

        public async Task<Rental> UpdateAsync(Rental rental)
        {
            // TEMPORARY: Clears the tracker to workaround errors when multiple tracked entities has the same PK
            _context.ChangeTracker.Clear();

            _context.Update(rental);
            await _context.SaveChangesAsync();
            return rental;
        }

        public async Task<PagedList<Rental>> GetAllAsync(int pageNumber, int pageSize)
        {
            IQueryable<Rental> query = _context.Rental
                .Include(x => x.Customer)
                .Include(x => x.Car)
                .AsQueryable();

            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Rental?> GetAsync(int id)
        {
            return await _context.Rental
                .Where(x => x.RentalId == id)
                .Include(x => x.Customer)
                .Include(x => x.Car)
                .FirstOrDefaultAsync();
        }

        // Temporary method overload
        public async Task<Rental?> GetAsync(uint id)
        {
            return await _context.Rental
                .Where(x => x.RentalId == id)
                .Include(x => x.Customer)
                .Include(x => x.Car)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> IsAvailableAsync(uint id)
        {
            bool hasActiveRental = await _context.Rental.Where(x => x.CarId == id && x.HasReturned == false).AnyAsync();

            return !hasActiveRental;
        }
    }
}
