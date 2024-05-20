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
            CreateMap<AddressDTO, Address>()
                .ForPath(dest => dest.PostalCode.City, act => act
                    .MapFrom(scr => scr.City))
                .ForPath(dest => dest.PostalCode.PostalcodeNumber, act => act
                    .MapFrom(scr => scr.PostalCodeNumber)).ReverseMap(); ;

           
            CreateMap<CreateAddressDTO, Address>()
                .ConstructUsing(src =>
                    new Address(src.Street, src.HouseNumber, src.Floor, src.DoorNumber, src.City, src.PostalCode))
                .ForPath(dest => dest.PostalCode.City, act => act
                    .MapFrom(scr => scr.City))
                .ForPath(dest => dest.PostalCode.PostalcodeNumber, act => act
                    .MapFrom(scr => scr.PostalCode));
            //CreateMap< Address,CreateAddressDTO>()
            //    .ForMember(dest => dest.City, act => act
            //        .MapFrom(scr => scr.PostalCode.City))
            //    .ForMember(dest => dest.PostalCode, act => act
            //        .MapFrom(scr => scr.PostalCode.PostalcodeNumber));
            CreateMap<UpdateAddressDTO, Address>()
                .ConstructUsing(src =>
                    new Address(src.Street, src.HouseNumber, src.Floor, src.DoorNumber, src.City, src.PostalCodeNumber))
                .ForPath(dest => dest.PostalCode.City, act => act
                    .MapFrom(scr => scr.City))
                .ForPath(dest => dest.PostalCode.PostalcodeNumber, act => act
                    .MapFrom(scr => scr.PostalCodeNumber)).ReverseMap();

            CreateMap<Address, DeleteAddressDTO>().ReverseMap();

        }
    }
}
