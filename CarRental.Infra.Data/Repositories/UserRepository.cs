using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Infra.Data.Context;
using System.Data.Entity;

namespace CarRental.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            User? user = await _context.User.FindAsync(id);

            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }

            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User?> GetAsync(int id)
        {
            return await _context.User.Where(x => x.UserId == id).FirstOrDefaultAsync();
        }
    }
}
