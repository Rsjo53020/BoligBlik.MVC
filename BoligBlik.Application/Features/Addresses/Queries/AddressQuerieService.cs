using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.Interfaces.Addresses.Queries;
using BoligBlik.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

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
          List<AddressDTO> addressDtos = new List<AddressDTO>();
          foreach (var address in addresses)
          {
              addressDtos.Add(_mapper.Map<AddressDTO>(address));
          }
          return addressDtos;
        }
    }
}
