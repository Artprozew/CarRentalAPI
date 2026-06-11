using CarRental.API.Extensions;
using CarRental.API.Models;
using CarRental.Application.DTOs;
using CarRental.Domain.Entities;
using CarRental.Domain.Pagination;
using CarRentalDTO.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : Controller
    {
        private readonly IRentalService _service;

        public RentalController(IRentalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<Rental>>> GetRentals([FromQuery]PaginationParams paginationParams)
        {
            PagedList<RentalDTO> rentalDTOs = await _service.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader
                (rentalDTOs.CurrentPage, rentalDTOs.PageSize, rentalDTOs.TotalCount, rentalDTOs.TotalPages));

            return Ok(rentalDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRentalById(int id)
        {
            RentalDTO rentalDTO = await _service.GetAsync(id);

            if (rentalDTO == null)
            {
                return NotFound("Rental not found");
            }

            return Ok(rentalDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddRental(RentalPostDTO rentalPostDTO)
        {
            bool isAvailable = await _service.IsAvailableAsync(rentalPostDTO.CarId);

            if (!isAvailable)
            {
                return BadRequest("The car is not available for rental");
            }

            rentalPostDTO.RentalDate = DateTime.Now;
            rentalPostDTO.HasReturned = false;

            RentalDTO rentalDTO = await _service.CreateAsync(rentalPostDTO);

            if (rentalDTO == null)
            {
                return BadRequest("Error registering rental");
            }

            return Ok("Rental registered successfully");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRental(RentalPutDTO rentalPutDTO)
        {
            RentalDTO rentalDTO = await _service.GetAsync(rentalPutDTO.RentalId);

            if (rentalDTO == null)
            {
                return NotFound("Rental not found");
            }

            rentalDTO.ReturnDate = rentalPutDTO.ReturnDate;
            rentalDTO.HasReturned = rentalPutDTO.HasReturned;
            rentalDTO.TotalPrice = rentalPutDTO.TotalPrice;

            rentalDTO = await _service.UpdateAsync(rentalDTO);

            if (rentalDTO == null)
            {
                return BadRequest("Error updating rental");
            }

            return Ok("Rental updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRental(int id)
        {
            RentalDTO rental = await _service.DeleteAsync(id);

            if (rental == null)
            {
                return BadRequest("Error deleting rental");
            }

            return Ok(rental);
        }
    }
}
