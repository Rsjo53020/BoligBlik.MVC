using BoligBlik.Application.DTO.User;

namespace BoligBlik.Application.Interfaces.Users.Queries
{
    public interface IUserQuerieService
    {
        Task<UserDTO> ReadUserAsync(string email);
        Task<IEnumerable<UserDTO>> ReadAllUsersAsync();
    }
}
