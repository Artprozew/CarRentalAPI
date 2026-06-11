
using AutoMapper;
using CarRental.Application.DTOs;
using CarRental.Application.Interfaces;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Pagination;

namespace CarRental.Application.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<CarDTO> CreateAsync(CarDTO carDTO)
        {
            Car car = _mapper.Map<Car>(carDTO);
            Car createdCar = await _carRepository.CreateAsync(car);
            return _mapper.Map<CarDTO>(createdCar);
        }

        public async Task<CarDTO> DeleteAsync(uint id)
        {
            Car? deletedCar = await _carRepository.DeleteAsync(id);
            return _mapper.Map<CarDTO>(deletedCar);
        }

        public async Task<CarDTO> UpdateAsync(CarDTO carDTO)
        {
            Car car = _mapper.Map<Car>(carDTO);
            Car updatedCar = await _carRepository.UpdateAsync(car);
            return _mapper.Map<CarDTO>(updatedCar);
        }

        public async Task<PagedList<CarDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            PagedList<Car> cars = await _carRepository.GetAllAsync(pageNumber, pageSize);
            IEnumerable<CarDTO> carDTOs = _mapper.Map<IEnumerable<CarDTO>>(cars);

            return new PagedList<CarDTO>(carDTOs, pageNumber, pageSize, cars.TotalCount);
        }

        public async Task<CarDTO> GetAsync(int id)
        {
            Car? car = await _carRepository.GetAsync(id);
            return _mapper.Map<CarDTO>(car);
        }
    }
}
