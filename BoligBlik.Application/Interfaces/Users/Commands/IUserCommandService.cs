using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.Users.Commands
{
    /// <summary>
    /// Interface for the UserCommandService
    /// </summary>
    public interface IUserCommandService
    {
        void CreateUser(CreateUserDTO request);
        void UpdateUser(UserDTO request);
        void DeleteUser(Guid id);
    }
}
