using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.Users
{
    public class UserQuerieRepo : IUserQuerieRepo
    {
        //context
        private readonly BoligBlikContext _dbContext;
        //logger
        private readonly ILogger<User> _logger;

        public UserQuerieRepo(BoligBlikContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// reads a user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<User> ReadUserAsync(string email)
        {
            try
            {
                return await _dbContext.Users.AsNoTracking()
                    .FirstOrDefaultAsync(u => u.EmailAddress == email);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in readUser in UserRepository " + ex.Message);
                throw new ApplicationException("Error in readUser in UserRepository ", ex);
            }
        }
        /// <summary>
        /// reads all users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> ReadAllUsersAsync()
        {
            try
            {
                return await _dbContext.Users.AsNoTracking().ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ReadAll in user: " + ex.Message);
                return Enumerable.Empty<User>();
            }
        }
    }
}
