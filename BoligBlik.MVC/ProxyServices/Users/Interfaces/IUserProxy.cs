using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.ProxyServices.Users.Interfaces
{
    public interface IUserProxy
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<bool> UpdateUserAsync(UpdateUserDTO user);
        Task<UserDTO> GetUserAsync(string email);
    }
}
