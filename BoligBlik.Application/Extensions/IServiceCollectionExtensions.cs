using BoligBlik.Application.Extensions.BoardMembers;
using BoligBlik.Application.Extensions.User;
using Microsoft.Extensions.DependencyInjection;

namespace BoligBlik.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //Add features
            //BoardMemberServiceCollection.AddBoardMember(services);
            //UserServiceCollectionExtentions.AddUsersService(services);
        }
    }
}
