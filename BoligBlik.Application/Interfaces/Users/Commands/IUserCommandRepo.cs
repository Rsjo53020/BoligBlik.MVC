using BoligBlik.Domain.Entities;
using System.Runtime.ConstrainedExecution;

namespace BoligBlik.Application.Interfaces.Users.Commands
{
    /// <summary>
    /// Interface for the UserCommandRepo
    /// </summary>
    public interface IUserCommandRepo
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
