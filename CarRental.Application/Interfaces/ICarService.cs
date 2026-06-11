using CarRental.Application.DTOs;
using CarRental.Domain.Pagination;

namespace CarRental.Application.Interfaces
{
    public interface ICarService
    {
        Task<CarDTO> CreateAsync(CarDTO carDTO);
        Task<CarDTO> UpdateAsync(CarDTO carDTO);
        Task<CarDTO> DeleteAsync(uint id);
        Task<CarDTO> GetAsync(int id);
        Task<PagedList<CarDTO>> GetAllAsync(int pageNumber, int pageSize);
    }
}
