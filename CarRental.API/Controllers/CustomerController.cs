using AutoMapper;
using CarRental.API.DTOs;
using CarRental.API.Interfaces;
using CarRental.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            IEnumerable<Customer> customer = await _customerRepository.GetAll();
            IEnumerable<CustomerDTO> customersDTO = _mapper.Map<IEnumerable<CustomerDTO>>(customer);

            return Ok(customersDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomerById(int id)
        {
            Customer customer = await _customerRepository.SelectByPrimaryKey(id);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            CustomerDTO customerDTO = _mapper.Map<CustomerDTO>(customer);

            return Ok(customerDTO);
        }

        [HttpPost]
        public async Task<ActionResult> SetCustomer(CustomerDTO customerDTO)
        {
            Customer customer = _mapper.Map<Customer>(customerDTO);

            _customerRepository.Create(customer);

            if (await _customerRepository.SaveAllAsync())
            {
                return Ok("Customer registered successfully");
            }

            return BadRequest("Error registering customer");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(CustomerDTO customerDTO)
        {
            Customer customer = _mapper.Map<Customer>(customerDTO);

            _customerRepository.Update(customer);
            if (await _customerRepository.SaveAllAsync())
            {
                return Ok("Customer updated successfully");
            }

            return BadRequest("Error updating customer");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            Customer customer = await _customerRepository.SelectByPrimaryKey(id);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            _customerRepository.Delete(customer);

            if (await _customerRepository.SaveAllAsync())
            {
                return Ok("Customer deleted successfully");
            }

            return BadRequest("Error deleting customer");
        }
    }
}
