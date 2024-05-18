using AutoMapper;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Entities;

namespace BoligBlik.Application.Common.Mappings
{
    public class AddressMappingProfile :Profile
    {
        public AddressMappingProfile()
        {
            //CreateAddressDTO
            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressDTO>().ReverseMap();


        }
    }
}
