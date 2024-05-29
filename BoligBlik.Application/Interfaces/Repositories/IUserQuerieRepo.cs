using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.Repositories
{
    /// <summary>
    /// Ínterface for the UserQuerieRepo
    /// </summary>
    public interface IUserQuerieRepo
    {
        Task<User> ReadUserAsync(string email);
        Task<IEnumerable<User>> ReadAllUsersAsync();
    }
}
