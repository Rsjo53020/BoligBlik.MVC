using BoligBlik.MVC.DTO.User;

namespace BoligBlik.MVC.ProxyServices.Users.Interfaces
{
    public interface IUserProxy
    {
        Task<bool> CreateUserAsync(CreateUserDTO user);
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<IEnumerable<UserDTO>> GetUsersWithoutAddressAsync();
        Task<UserDTO> GetUserAsync(string email);
        Task DeleteUserAsync(Guid id, string rowVersion);
        Task<bool> UpdateUserAsync(UserDTO user);
    }
}
