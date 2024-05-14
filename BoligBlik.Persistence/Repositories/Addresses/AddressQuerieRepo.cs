using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Persistence.Repositories.Addresses
{
    public class AddressQuerieRepo : IAddressQuerieRepo
    {
        public Task<IEnumerable<AddressDTO>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
