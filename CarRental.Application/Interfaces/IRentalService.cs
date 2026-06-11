using CarRental.Application.DTOs;
using CarRental.Domain.Pagination;

namespace CarRentalDTO.Application.Interfaces
{
    public interface IRentalService
    {
        Task<RentalDTO> CreateAsync(RentalPostDTO rentalPostDTO);
        Task<RentalDTO> UpdateAsync(RentalDTO rentalDTO);
        Task<RentalDTO> DeleteAsync(int id);
        Task<RentalDTO> GetAsync(int id);
        Task<RentalDTO> GetAsync(uint id);
        Task<PagedList<RentalDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<bool> IsAvailableAsync(uint id);
    }
}
