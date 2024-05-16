using BoligBlik.Application.DTO.Adress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.Address;

namespace BoligBlik.Application.Interfaces.Addresses.Commands
{
    public interface IAddressCommandService
    {
        void Create(CreateAddressDTO request);
    }
}
