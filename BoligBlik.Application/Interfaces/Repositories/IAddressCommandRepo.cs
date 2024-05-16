using BoligBlik.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Entities;

namespace BoligBlik.Application.Interfaces.Repositories
{
    public interface IAddressCommandRepo
    {
        void Create(Address request);
    }
}
