using AutoMapper;
using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.Models.Addresses;

namespace BoligBlik.MVC.Mappings
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<AddressDTO, AddressViewModel>()
                .ForMember(dest => dest.Bookings, opt => opt
                    .MapFrom(src => src.Bookings))
                .ForMember(dest => dest.Users, opt => opt
                    .MapFrom(src => src.Users))
                .ReverseMap();

            CreateMap<CreateAddressDTO, CreateAddressViewModel>().ReverseMap();

        }
    }
}
