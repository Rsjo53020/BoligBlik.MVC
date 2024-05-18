using BoligBlik.Application.DTO.Adress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Entities;

namespace BoligBlik.Application.Interfaces.Addresses.Queries
{
    public interface IAddressQuerieService
    {
        Task<IEnumerable<AddressDTO>> ReadAllAsync();
        Task<AddressDTO> ReadAddress(Address address);
    }
}
