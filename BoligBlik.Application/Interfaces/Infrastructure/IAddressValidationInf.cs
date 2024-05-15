using BoligBlik.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.Infrastructure
{
    public interface IAddressValidationInf
    {
        Task<bool> ValidateAddressAsync(Address address);
       
    }
}
