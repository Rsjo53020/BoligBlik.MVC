using AutoMapper;
using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Application.Interfaces.Users.Queries;

namespace BoligBlik.Application.Features.Users.Queries
{
    public class UserQueriesService : IUserQuerieService
    {
        //Dependencies
        private readonly IUserQuerieRepo _userRepo;
        private readonly IMapper _mapper;

        //Constructor
        public UserQueriesService(IMapper mapper, IUserQuerieRepo userQuerieRepo)
        {
            _mapper = mapper;
            _userRepo = userQuerieRepo;
        }

        /// <summary>
        /// This method reads a user by Email
        /// </summary>
        public async Task<UserDTO> ReadUserAsync(string email)
        {
            var user = await _userRepo.ReadUserAsync(email);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task<UserDTO> ReadUserAsync(Guid Id)
        {
            var user = await _userRepo.ReadUserAsync(Id);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        /// <summary>
        /// This method reads all users
        /// </summary>
        public async Task<IEnumerable<UserDTO>> ReadAllUsersAsync()
        {
            var users = await _userRepo.ReadAllUsersAsync();
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                userDTOs.Add(_mapper.Map<UserDTO>(user));
            }
            return userDTOs;
        }
    }
}
