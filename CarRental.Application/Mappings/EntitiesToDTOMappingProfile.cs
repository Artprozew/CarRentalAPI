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
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Car, CarDTO>().ReverseMap();
            CreateMap<RentalDTO, Rental>().ReverseMap()
                .ForMember(dest => dest.CarDTO, opt => opt.MapFrom(x => x.Car))
                .ForMember(dest => dest.CustomerDTO, opt => opt.MapFrom(x => x.Customer));
            CreateMap<Rental, RentalPostDTO>().ReverseMap();
            CreateMap<Rental, RentalPutDTO>().ReverseMap();
        }
    }
}
