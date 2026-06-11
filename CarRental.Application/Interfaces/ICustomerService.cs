using CarRental.Application.DTOs;
using CarRental.Domain.Pagination;

namespace CarRental.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> CreateAsync(CustomerDTO customerDTO);
        Task<CustomerDTO> UpdateAsync(CustomerDTO customerDTO);
        Task<CustomerDTO> DeleteAsync(uint id);
        Task<CustomerDTO> GetAsync(int id);
        Task<PagedList<CustomerDTO>> GetAllAsync(int pageNumber, int pageSize);
    }
}
