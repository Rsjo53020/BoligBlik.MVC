namespace BoligBlik.Application.Interfaces.Users.Queries
{
    /// <summary>
    /// Ínterface for the UserQuerieRepo
    /// </summary>
    public interface IUserQuerieRepo
    {
        Domain.Entities.User ReadUser(string title);
        IEnumerable<Domain.Entities.User> ReadAllUsers();
    }
}
