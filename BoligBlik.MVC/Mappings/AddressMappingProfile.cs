﻿using AutoMapper;
using BoligBlik.MVC.DTO.Adress;
using BoligBlik.MVC.Models.Addresses;

namespace BoligBlik.MVC.Mappings
{
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile()
        {
            CreateMap<AddressDTO, AddressViewModel>();
            CreateMap<AddressViewModel, AddressDTO>();
        }
    }
}
