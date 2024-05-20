using AutoMapper;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Entities;

namespace BoligBlik.Application.Common.Mappings
{
    public class AddressMappingProfile :Profile
    {
        public AddressMappingProfile()
        {
            //Create Map Address <- -> DTO
            CreateMap<AddressDTO, Address>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();
            //.ReverseMap()
            //.ForMember(dest => dest.Bookings, opt => opt
            //    .MapFrom(src => src.Bookings))
            //.ForMember(dest => dest.Users, opt => opt
            //    .MapFrom(src => src.Users));
        }
    }
}
