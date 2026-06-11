using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Pagination;
using CarRental.Infra.Data.Context;
using CarRental.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infra.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Car> CreateAsync(Car car)
        {
            _context.Car.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car?> DeleteAsync(uint id)
        {
            Car? car = await _context.Car.FindAsync(id);

            if (car != null)
            {
                _context.Car.Remove(car);
                await _context.SaveChangesAsync();
            }

            return car;
        }

        public async Task<Car> UpdateAsync(Car car)
        {
            _context.Update(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<PagedList<Car>> GetAllAsync(int pageNumber, int pageSize)
        {
            IQueryable<Car> query = _context.Car.AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Car?> GetAsync(int id)
        {
            return await _context.Car.Where(x => x.CarId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
