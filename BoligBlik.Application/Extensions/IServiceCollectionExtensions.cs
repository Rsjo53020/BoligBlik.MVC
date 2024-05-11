using BoligBlik.Application.Extensions.BoardMember;
using BoligBlik.Application.Extensions.User;
using BoligBlik.Application.Features.BoardMember.Commands;
using BoligBlik.Application.Features.BoardMember.Mappers;
using BoligBlik.Application.Features.BoardMember.Queries;
using BoligBlik.Application.Interfaces;
using BoligBlik.Application.Interfaces.BoardMember.Commands;
using BoligBlik.Application.Interfaces.BoardMember.Mappers;
using BoligBlik.Application.Interfaces.BoardMember.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BoligBlik.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //Add features
            BoardMemberServiceCollection.AddBoardMember(services);
            UserServiceCollectionExtentions.AddUsersService(services);
        }
    }
}
