using BoligBlik.Application.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Features.User.Queries.Interfaces
{
    public interface IUserGet
    {
        UserGetDto Read(string email);
    }
}
