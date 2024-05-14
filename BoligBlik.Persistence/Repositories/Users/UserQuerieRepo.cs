using BoligBlik.Application.Interfaces.Users.Queries;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.Users
{
    public class UserQuerieRepo : IUserQuerieRepo
    {
        private readonly BoligBlikContext _dbContext;
        private readonly ILogger<User> _logger;

        public UserQuerieRepo(BoligBlikContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> ReadUserAsync(string email)
        {
            try
            {
                return await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.EmailAddress == email);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in readUser in UserRepository " + ex.Message);
                throw new ApplicationException("Error in readUser in UserRepository ", ex);
            }
        }

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
