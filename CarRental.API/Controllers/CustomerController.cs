using CarRental.Domain.Entities;
using CarRental.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using CarRental.Application.Interfaces;
using CarRental.Infra.IoC;
using CarRental.API.Models;
using CarRental.API.Extensions;
using CarRental.Domain.Pagination;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] // Requests JWT auth to use the endpoints
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;

        public CustomerController(ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers([FromQuery]PaginationParams paginationParams)
        {
            PagedList<CustomerDTO> customersDTO = await _customerService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader
                (customersDTO.CurrentPage, customersDTO.PageSize, customersDTO.TotalCount, customersDTO.TotalPages));

            return Ok(customersDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            CustomerDTO customerDTO = await _customerService.GetAsync(id);

            if (customerDTO == null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customerDTO);
        }

        [HttpPost]
        public async Task<ActionResult> SetCustomer(CustomerDTO customerDTO)
        {
            customerDTO = await _customerService.CreateAsync(customerDTO);

            if (customerDTO == null)
            {
                return BadRequest("Error registering customer");
            }

            return Ok("Customer registered successfully");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(CustomerDTO customerDTO)
        {
            customerDTO = await _customerService.UpdateAsync(customerDTO);

            if (customerDTO == null)
            {
                return BadRequest("Error updating customer");
            }

            return Ok("Customer updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(uint id)
        {
            int? userId = User.GetId();

            if (userId == null)
            {
                return Unauthorized("Not logged in");
            }

            UserDTO? user = await _userService.GetAsync(userId.Value);

            if (!user.IsAdmin)
            {
                return Unauthorized("Not enough permissions");
            }

            CustomerDTO customerDTO = await _customerService.DeleteAsync(id);

            if (customerDTO == null)
            {
                return BadRequest("Error deleting customer");
            }

            return Ok("Customer deleted successfully");
        }
    }
}
