using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Users.Mappers;
using BoligBlik.Application.Interfaces.Users.Queries;

namespace BoligBlik.Application.Features.User.Queries
{
    /// <summary>
    /// this class is responsible for the user queries
    /// </summary>
    public class UserQuerieService : IUserQuerieService
    {
        // depencies
        private readonly IUserQuerieRepo _userRepo;
        private readonly IUserMapper _mapper;

        // constructor
        public UserQuerieService(IUserMapper userDTOMapper, IUserQuerieRepo userQuerieRepo)
        {
            _mapper = userDTOMapper;
            _userRepo = userQuerieRepo;
        }

        // this method reads a user by Email
        public UserDTO ReadUser(string email)
        {
            var user = _userRepo.ReadUser(email);
            var userDTO = _mapper.MapModelToUserDTO(user);
            return userDTO;
        }

        // this method reads all users
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
