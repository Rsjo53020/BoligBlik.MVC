using AutoMapper;
using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.User;

namespace BoligBlik.Application.Common.Mappings
{
    public class AddressMappingProfile :Profile
    {
        public AddressMappingProfile()
        {
            //CreateAddressDTO
            CreateMap<AddressDTO, Address>();
            CreateMap<Address, AddressDTO>();


        }
    }
}
