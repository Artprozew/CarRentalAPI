using CarRental.Application.DTOs;

namespace CarRental.Application.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerDTO> CreateAsync(CustomerDTO customerDTO);
        Task<CustomerDTO> UpdateAsync(CustomerDTO customerDTO);
        Task<CustomerDTO> DeleteAsync(int id);
        Task<CustomerDTO> GetAsync(int id);
        Task<IEnumerable<CustomerDTO>> GetAllAsync();
    }
}
