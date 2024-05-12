using BoligBlik.Application.DTO.User;

namespace BoligBlik.Application.Interfaces.Users.Queries
{
    /// <summary>
    /// Interface for the UserQuerieService
    /// </summary>
    public interface IUserQuerieService
    {
        public UserDTO ReadUser(string email);
        public IEnumerable<UserDTO> ReadAllUsers();
    }
}
