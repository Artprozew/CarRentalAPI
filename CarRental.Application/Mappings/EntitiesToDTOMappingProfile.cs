using AutoMapper;
using CarRental.Application.DTOs;
using CarRental.Domain.Entities;

namespace CarRental.Application.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
