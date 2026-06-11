using AutoMapper;
using CarRental.Application.DTOs;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Pagination;

namespace CarRental.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> CreateAsync(CustomerDTO customerDTO)
        {
            Customer customer = _mapper.Map<Customer>(customerDTO);
            Customer createdCustomer = await _customerRepository.CreateAsync(customer);

            return _mapper.Map<CustomerDTO>(createdCustomer);
        }

        public async Task<CustomerDTO> DeleteAsync(uint id)
        {
            Customer? deletedCustomer = await _customerRepository.DeleteAsync(id);
            return _mapper.Map<CustomerDTO>(deletedCustomer);
        }
        public async Task<CustomerDTO> UpdateAsync(CustomerDTO customerDTO)
        {
            Customer customer = _mapper.Map<Customer>(customerDTO);
            Customer updatedCustomer = await _customerRepository.UpdateAsync(customer);

            return _mapper.Map<CustomerDTO>(updatedCustomer);
        }

        public async Task<PagedList<CustomerDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            PagedList<Customer> customers = await _customerRepository.GetAllAsync(pageNumber, pageSize);
            IEnumerable<CustomerDTO> customersDTOs = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            return new PagedList<CustomerDTO>(customersDTOs, pageNumber, pageSize, customers.TotalCount);
        }

        public async Task<CustomerDTO> GetAsync(int id)
        {
            Customer? customer = await _customerRepository.GetAsync(id);
            return _mapper.Map<CustomerDTO>(customer);
        }
    }
}
