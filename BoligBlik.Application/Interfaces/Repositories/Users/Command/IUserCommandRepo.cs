using BoligBlik.Domain.Entities;
using System.Runtime.ConstrainedExecution;

namespace BoligBlik.Application.Interfaces.Repositories.Users.Command
{
    public interface IUserCommandRepo
    {
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(Guid id, byte[] rowVersion);
    }
}
