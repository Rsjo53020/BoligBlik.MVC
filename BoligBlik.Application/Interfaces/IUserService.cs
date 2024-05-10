using BoligBlik.Application.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserDto request);
        Task UpdateUserAsync(UpdateUserDto request);
        Task DeleteUserAsync(string email);
        Task<IEnumerable<GetUserDto>> GetAllUsersAsync();
        Task<GetUserDto> GetUserAsync(string email);
    }
}
