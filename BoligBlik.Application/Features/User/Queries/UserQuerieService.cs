using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Users.Mappers;
using BoligBlik.Application.Interfaces.Users.Queries;

namespace BoligBlik.Application.Features.User.Queries
{
    //navnet på klasse forkert
    public class UserQuerieService : IUserQuerieService
    {
        //Dependencies
        private readonly IUserQuerieRepo _userRepo;
        private readonly IUserMapper _mapper;

        //Constructor
        public UserQuerieService(IUserMapper userDTOMapper, IUserQuerieRepo userQuerieRepo)
        {
            _mapper = userDTOMapper;
            _userRepo = userQuerieRepo;
        }

        /// <summary>
        /// This method reads a user by Email
        /// </summary>
        public UserDTO ReadUser(string email)
        {
            var user = _userRepo.ReadUser(email);
            var userDTO = _mapper.MapModelToUserDTO(user);
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
                userDTOs.Add(_mapper.MapModelToUserDTO(user));
            }
            return userDTOs;
        }
    }
}
