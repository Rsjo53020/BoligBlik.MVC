using BoligBlik.Domain.Entities;
using System.Runtime.ConstrainedExecution;

namespace BoligBlik.Application.Interfaces.Repositories
{
    /// <summary>
    /// Interface for the UserCommandRepo
    /// </summary>
    public interface IUserCommandRepo
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id, Byte[] rowVersion);
    }
}
