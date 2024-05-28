using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Common.Exceptions
{
    public class AddressesNotFoundException : Exception
    {
        public AddressesNotFoundException(string info) : base(info)
        {

        }
      

    }
}
