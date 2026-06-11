using AutoMapper;
using CarRental.Application.DTOs;
using CarRental.Application.Interfaces;
using CarRental.Domain.Interfaces;
using CarRental.Domain.SystemModels;

namespace CarRental.Application.Services
{
    public class SystemService : ISystemService
    {
        private readonly ISystemRepository _systemRepository;
        private readonly IMapper _mapper;

        public SystemService(ISystemRepository systemRepository, IMapper mapper)
        {
            _systemRepository = systemRepository;
            _mapper = mapper;
        }

        public async Task<ItemsQuantityDTO> GetItemsQuantityAsync()
        {
            ItemsQuantity itemsQuantity = await _systemRepository.GetItemsQuantityAsync();
            return _mapper.Map<ItemsQuantityDTO>(itemsQuantity);
        }
    }
}
