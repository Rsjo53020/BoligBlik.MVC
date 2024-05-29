using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.ProxyServices.Users.Interfaces
{
    public interface IUserProxy
    {
        Task<bool> CreateUserAsync(CreateUserDTO user);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<bool> UpdateUserAsync(UserDTO user);
        Task<UserDTO> GetUserAsync(string email);
        Task DeleteUserAsync(Guid id, string rowVersion);
    }
}
