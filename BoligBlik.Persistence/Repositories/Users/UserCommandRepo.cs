using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.Users
{
    public class UserCommandRepo : IUserCommandRepo
    {
        //context
        private readonly BoligBlikContext _dbContext;
        //logger
        private readonly ILogger<User> _logger;

        public UserCommandRepo(BoligBlikContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// create a user
        /// </summary>
        /// <param name="user"></param>
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
        /// <summary>
        /// update a user
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            try
            {
                _dbContext.Update(user)
                    .Property(b => b.RowVersion).OriginalValue = user.RowVersion;
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in update in user: " + ex.Message);
            }
        }
        /// <summary>
        /// delete a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        public void DeleteUser(Guid id, Byte[] rowVersion)
        {
            try
            {
                _dbContext.Remove(_dbContext.Users
                    .Where(b => b.Id == id).FirstOrDefault())
                    .Property(b => b.RowVersion).OriginalValue = rowVersion;
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in delete in user: " + ex.Message);
            }
        }
    }
}
