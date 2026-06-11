using CarRental.Domain.Entities;

namespace CarRental.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string senha);
        Task<bool> UserExistsAsync(string email);
        public string GenerateToken(int id, string email);
        Task<User> GetUserByEmailAsync(string email);
    }
}
