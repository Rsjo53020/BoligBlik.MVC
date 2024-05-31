using BoligBlik.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Entities;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.Repositories
{
    public interface IAddressCommandRepo
    {
        void CreateAddress(Address address);
        void UpdateAddress(Address address);
        void DeleteAddress(Address address);
    }
}
