using AutoMapper;
using BoligBlik.Application.Common.Mappings;
using BoligBlik.Application.Features.BoardMembers.Commands;
using BoligBlik.Application.Features.BoardMembers.Queries;
using BoligBlik.Application.Interfaces.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.BoardMembers.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BoligBlik.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //Add features
            AddBoardMember(services);
            ConfigureBoardMemberMappers(services);
            //UserServiceCollectionExtentions.AddUsersService(services);
        }

        private static void AddBoardMember(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IBoardMemberCommandService, BoardMemberCommandService>();
            services.AddScoped<IBoardMemberQuerieService, BoardMemberQuerieService>();
        }

        private static void ConfigureBoardMemberMappers(this IServiceCollection services)
        {
            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BoardMemberMappingProfile());
            });

            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
    }
}
