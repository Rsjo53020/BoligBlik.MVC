namespace BoligBlik.Application.Interfaces.Users.Commands
{
    /// <summary>
    /// Interface for the UserCommandRepo
    /// </summary>
    public interface IUserCommandRepo
    {
        Task CreateUserAsync(Domain.Entities.User user);
        Task UpdateUserAsync(Domain.Entities.User user);
        Task DeleteUserAsync(Domain.Entities.User user);
    }
}
