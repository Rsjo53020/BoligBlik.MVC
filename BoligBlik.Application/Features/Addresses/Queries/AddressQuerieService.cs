﻿using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.Interfaces.Addresses.Queries;
using BoligBlik.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoligBlik.Application.Common.Exceptions;
using BoligBlik.Domain.Exceptions;
using BoligBlik.Entities;

namespace BoligBlik.Application.Features.Addresses.Queries
{
    public class AddressQuerieService : IAddressQuerieService
    {
        private readonly IAddressQuerieRepo _addressRepo;
        private readonly IMapper _mapper;
        public AddressQuerieService(IAddressQuerieRepo addressRepo, IMapper mapper)
        {
            _addressRepo = addressRepo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<AddressDTO>> ReadAllAsync()
        {
          var addresses= await _addressRepo.ReadAllAsync();
          List<AddressDTO> addressList = new List<AddressDTO>();
          foreach (var address in addresses)
          {
              addressList.Add(_mapper.Map<AddressDTO>(address));
          }

          return addressList;


          //return addressDtos;
        }

        public async Task<AddressDTO> ReadAddress(Address address)
        { 
            var response = await _addressRepo.ReadAddress(address);
            var addressMap = _mapper.Map<AddressDTO>(response);
           
            if (address is null)
            {
                throw new AddressNotFoundException(response.Id);
            }
           
            return addressMap;

        }
    }
}
