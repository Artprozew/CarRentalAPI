using AutoMapper;
using CarRental.API.DTOs;
using CarRental.Domain.Entities;

namespace CarRental.API.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
