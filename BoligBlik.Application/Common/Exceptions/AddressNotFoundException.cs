using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Common.Exceptions
{
    public class AddressNotFoundException : Exception
    {
        public AddressNotFoundException(Guid id) : base($"Address with Id: {id} was not found")
        {

        }

    }
}
