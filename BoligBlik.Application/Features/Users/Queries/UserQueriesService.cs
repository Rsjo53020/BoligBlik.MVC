using AutoMapper;
using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Application.Interfaces.Users.Queries;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Application.Features.Users.Queries
{
    public class UserQueriesService : IUserQuerieService
    {
        //Dependencies
        private readonly IUserQuerieRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<UserQueriesService> _logger;

        //Constructor
        public UserQueriesService(IMapper mapper, IUserQuerieRepo userQuerieRepo, ILogger<UserQueriesService> logger)
        {
            _mapper = mapper;
            _userRepo = userQuerieRepo;
            _logger = logger;
        }

        /// <summary>
        /// This method reads a user by Email
        /// </summary>
        public async Task<UserDTO> ReadUserAsync(string email)
        {
            try
            {
                var user = await _userRepo.ReadUserAsync(email);
                var userDTO = _mapper.Map<UserDTO>(user);
                return userDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("something went wrong when reading a user", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// This method reads all users
        /// </summary>
        public async Task<IEnumerable<UserDTO>> ReadAllUsersAsync()
        {
            try
            {
                var users = await _userRepo.ReadAllUsersAsync();
                List<UserDTO> userDTOs = new List<UserDTO>();
                foreach (var user in users)
                {
                    userDTOs.Add(_mapper.Map<UserDTO>(user));
                }
                return userDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError("something went wrong when reading all users", ex.Message);
                return null;
            }
        }
    }
}
