using BoligBlik.Application.Interfaces.Users.Queries;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Persistence.Repositories.Queries
{
    public class UserQuerieRepo : IUserQuerieRepo
    {
        public User ReadUser(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ReadAllUsers()
        {
            throw new NotImplementedException();
        }
    }
}
