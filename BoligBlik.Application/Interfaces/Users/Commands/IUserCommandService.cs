using BoligBlik.Application.DTO.User;

namespace BoligBlik.Application.Interfaces.Users.Commands
{
    /// <summary>
    /// Interface for the UserCommandService
    /// </summary>
    public interface IUserCommandService
    {
        Task CreateUserAsync(CreateUserDTO request);
        Task UpdateUserAsync(UpdateUserDTO request);
        Task DeleteUserAsync(DeleteUserDTO request);
    }
}
