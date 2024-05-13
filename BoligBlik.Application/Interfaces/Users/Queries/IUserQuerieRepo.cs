using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.Users.Queries
{
    /// <summary>
    /// Ínterface for the UserQuerieRepo
    /// </summary>
    public interface IUserQuerieRepo
    {
        User ReadUser(string title);
        IEnumerable<User> ReadAllUsers();
    }
}
