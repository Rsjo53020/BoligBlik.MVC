using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.Interfaces.Addresses.Queries;
using BoligBlik.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Features.Addresses.Queries
{
    public class AddressQuerieService : IAddressQuerieService
    {
        private readonly IAddressQuerieRepo _addressRepo;
        public AddressQuerieService(IAddressQuerieRepo addressRepo)
        {
            _addressRepo = addressRepo;
        }
        public async Task<IEnumerable<AddressDTO>> ReadAllAsync()
        {
            return await _addressRepo.ReadAllAsync();
        }
    }
}
