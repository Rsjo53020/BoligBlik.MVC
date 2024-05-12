using BoligBlik.Application.Features.BoardMembers.Commands;
using BoligBlik.Application.Features.BoardMembers.Mappers;
using BoligBlik.Application.Features.BoardMembers.Queries;
using BoligBlik.Application.Interfaces.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.BoardMembers.Mappers;
using BoligBlik.Application.Interfaces.BoardMembers.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BoligBlik.Application.Extensions.BoardMembers
{
    public static class BoardMemberServiceCollection
    {
        public static IServiceCollection AddBoardMember(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IBoardMemberCommandService, BoardMemberCommandService>();
            services.AddScoped<IBoardMemberQuerieService, BoardMemberQuerieService>();

            //Mappers
            services.AddScoped<IBoardMemberDTOMapper, BoardMemberDTOmapper>();
            services.AddScoped<IBoardMemberMapper, BoardMemberMapper>();

            return services;
        }
    }
}
