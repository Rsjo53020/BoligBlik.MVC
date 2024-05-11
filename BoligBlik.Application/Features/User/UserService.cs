using BoligBlik.Application.Dto.User;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Features.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepo userRepo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateUserAsync(CreateUserDto request)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUserAsync(UpdateUserDto request)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUserAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetUserDto>> GetAllUsersAsync()
        {
            return await _userRepo.GetAllUsersAsync();
        }

        public async Task<GetUserDto> GetUserAsync(string email)
        {
            return await _userRepo.GetUserAsync(email);
        }
    }
}
