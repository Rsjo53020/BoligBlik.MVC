using BoligBlik.Application.Dto.User;
using BoligBlik.Application.Features.User.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Features.User.Queries
{
    public class UserGet : IUserGet
    {
        public UserGetDto Read(string email)
        {
            throw new NotImplementedException();
        }
    }
}
