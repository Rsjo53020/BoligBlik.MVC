using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Persistence.Repositories.Users
{
    public class UserCommandRepo : IUserCommandRepo
    {
        public Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
