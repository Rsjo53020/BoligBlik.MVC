using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.Users
{
    public class UserCommandRepo : IUserCommandRepo
    {
        private readonly BoligBlikContext _dbContext;
        private readonly ILogger<User> _logger;

        public UserCommandRepo(BoligBlikContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateUser(User user)
        {
            try
            {
                _dbContext.AddAsync(user);
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in create in user: " + ex.Message);
            }

        }

        public void UpdateUser(User user)
        {
            try
            {
                _dbContext.Update(user).Property(b => b.RowVersion).OriginalValue = user.RowVersion;
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in update in user: " + ex.Message);
            }
        }

        public void DeleteUser(Guid id)
        {
            try
            {
                _dbContext.Remove(_dbContext.Users.Where(b => b.Id == id).FirstOrDefault());
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in delete in user: " + ex.Message);
            }
        }
    }
}
