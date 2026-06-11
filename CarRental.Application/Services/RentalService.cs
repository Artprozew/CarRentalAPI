using AutoMapper;
using CarRental.Application.DTOs;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Pagination;
using CarRentalDTO.Application.Interfaces;

namespace CarRental.Application.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _repository;
        private readonly IMapper _mapper;

        public RentalService(IRentalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RentalDTO> CreateAsync(RentalPostDTO rentalPostDTO)
        {
            Rental rental = _mapper.Map<Rental>(rentalPostDTO);
            Rental createdRental = await _repository.CreateAsync(rental);
            return _mapper.Map<RentalDTO>(createdRental);
        }

        public async Task<RentalDTO> DeleteAsync(int id)
        {
            Rental? rental = await _repository.DeleteAsync(id);
            return _mapper.Map<RentalDTO>(rental);
        }

        public async Task<RentalDTO> UpdateAsync(RentalDTO rentalDTO)
        {
            Rental rental = _mapper.Map<Rental>(rentalDTO);
            Rental updatedRental = await _repository.UpdateAsync(rental);
            return _mapper.Map<RentalDTO>(updatedRental);
        }

        public async Task<PagedList<RentalDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            PagedList<Rental> rentals = await _repository.GetAllAsync(pageNumber, pageSize);
            IEnumerable<RentalDTO> rentalDTOs = _mapper.Map<IEnumerable<RentalDTO>>(rentals);

            return new PagedList<RentalDTO>(rentalDTOs, pageNumber, pageSize, rentals.TotalCount);
        }

        public async Task<RentalDTO> GetAsync(int id)
        {
            Rental? rental = await _repository.GetAsync(id);
            return _mapper.Map<RentalDTO>(rental);
        }

        public async Task<RentalDTO> GetAsync(uint id)
        {
            Rental? rental = await _repository.GetAsync(id);
            return _mapper.Map<RentalDTO>(rental);
        }

        public async Task<bool> IsAvailableAsync(uint id)
        {
            return await _repository.IsAvailableAsync(id);
        }
    }
}
