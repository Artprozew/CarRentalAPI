using CarRental.API.Extensions;
using CarRental.API.Models;
using CarRental.Application.DTOs;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarService _carService;

        public CarController(ICarRepository carRepository, ICarService carService)
        {
            _carRepository = carRepository;
            _carService = carService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars([FromQuery]PaginationParams paginationParams)
        {
            PagedList<CarDTO> carDTOs = await _carService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader
                (carDTOs.CurrentPage, carDTOs.PageSize, carDTOs.TotalCount, carDTOs.TotalPages));

            return Ok(carDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(int id)
        {
            CarDTO carDTO = await _carService.GetAsync(id);

            if (carDTO == null)
            {
                return NotFound("Car not found");
            }

            return Ok(carDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddCar(CarDTO carDTO)
        {
            carDTO = await _carService.CreateAsync(carDTO);

            if (carDTO == null)
            {
                return BadRequest("Error registering car");
            }

            return Ok("Car registered succesfully");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCar(CarDTO carDTO)
        {
            carDTO = await _carService.UpdateAsync(carDTO);

            if (carDTO == null)
            {
                return BadRequest("Error updating car");
            }

            return Ok("Car updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCar(uint id)
        {
            CarDTO carDTO = await _carService.DeleteAsync(id);

            if (carDTO == null)
            {
                return BadRequest("Error deleting customer");
            }

            return Ok("Car deleted successfully");
        }
    }
}
