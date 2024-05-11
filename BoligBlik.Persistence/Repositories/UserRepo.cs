using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BoligBlik.Application.Dto.User;
using BoligBlik.Application.Interfaces;
using BoligBlik.Application.Interfaces.Repositories;

namespace BoligBlik.Infrastructure.Services
{
    public class UserRepo : IUserRepo
    {
        public async Task<IEnumerable<GetUserDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<GetUserDto> GetUserAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}