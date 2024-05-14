using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.Users.Queries
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
