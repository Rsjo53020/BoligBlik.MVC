using BoligBlik.Application.DTO.User;

namespace BoligBlik.Application.Interfaces.Users.Commands
{
    /// <summary>
    /// Interface for the UserCommandService
    /// </summary>
    public interface IUserCommandService
    {
        Task<bool> CreateUserAsync(CreateUserDTO command);
        Task UpdateUserAsync(UpdateUserDTO command);
        Task DeleteUserAsync(DeleteUserDTO command);
    }
}
