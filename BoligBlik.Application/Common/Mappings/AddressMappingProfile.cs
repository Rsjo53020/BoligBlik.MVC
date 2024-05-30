using AutoMapper;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Domain.Entities;
using BoligBlik.Entities;

namespace BoligBlik.Application.Common.Mappings
{
    public class AddressMappingProfile : Profile
    {
        /// <summary>
        /// Creates AddressMapping and ReverseMap using Automapper 
        /// </summary>
        public AddressMappingProfile()
        {
            CreateMap<AddressDTO, Address>()
                .ForPath(dest => dest.PostalCode.City, act => act
                    .MapFrom(scr => scr.City))
                .ForPath(dest => dest.PostalCode.PostalcodeNumber, act => act
                    .MapFrom(scr => scr.PostalCodeNumber))
                .ForMember(dest => dest.Bookings, opt => opt.MapFrom(src => src.Bookings))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
                .ReverseMap();

            CreateMap<CreateAddressDTO, Address>()
                .ConstructUsing(src =>
                    new Address(src.Street, src.HouseNumber, src.Floor, src.DoorNumber, src.City, src.PostalCodeNumber))
                .ForPath(dest => dest.PostalCode.City, act => act
                    .MapFrom(scr => scr.City))
                .ForPath(dest => dest.PostalCode.PostalcodeNumber, act => act
                    .MapFrom(scr => scr.PostalCodeNumber)).ReverseMap();

            CreateMap<UpdateAddressDTO, Address>()
                .ConstructUsing(src =>
                    new Address(src.Street, src.HouseNumber, src.Floor, src.DoorNumber, src.City, src.PostalCodeNumber))
                .ForPath(dest => dest.PostalCode.City, act => act
                    .MapFrom(scr => scr.City))
                .ForPath(dest => dest.PostalCode.PostalcodeNumber, act => act
                    .MapFrom(scr => scr.PostalCodeNumber)).ReverseMap();


        }
    }
}
