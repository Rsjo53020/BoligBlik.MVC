using BoligBlik.Application.DTO.Adress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.Addresses.Commands
{
    public interface IAddressCommandService
    {
        void Create(AddressDTO request);
    }
}
