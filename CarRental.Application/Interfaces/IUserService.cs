using CarRental.Application.DTOs;
using CarRental.Domain.Pagination;

namespace CarRental.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserLoginDTO> CreateAsync(UserLoginDTO user);
        Task<UserDTO> UpdateAsync(UserDTO user);
        Task<UserDTO?> DeleteAsync(uint id);
        Task<UserDTO?> GetAsync(int id);
        Task<PagedList<UserDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<bool> RegisteredUserExistsAsync();
    }
}
