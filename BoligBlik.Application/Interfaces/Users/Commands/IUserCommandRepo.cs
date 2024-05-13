using BoligBlik.Domain.Entities;
using System.Runtime.ConstrainedExecution;

namespace BoligBlik.Application.Interfaces.Users.Commands
{
    /// <summary>
    /// Interface for the UserCommandRepo
    /// </summary>
    public interface IUserCommandRepo
    {
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
    }
}
