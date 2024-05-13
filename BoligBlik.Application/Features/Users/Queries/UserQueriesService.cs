using AutoMapper;
using BoligBlik.Application.DTO.User;
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
        public UserDTO ReadUser(string email)
        {
            var user = _userRepo.ReadUser(email);
            var userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        /// <summary>
        /// This method reads all users
        /// </summary>
        public IEnumerable<UserDTO> ReadAllUsers()
        {
            var users = _userRepo.ReadAllUsers();
            List<UserDTO> userDTOs = new List<UserDTO>();
            foreach (var user in users)
            {
                userDTOs.Add(_mapper.Map<UserDTO>(user));
            }
            return userDTOs;
        }
    }
}
