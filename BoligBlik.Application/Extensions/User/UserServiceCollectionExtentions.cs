using BoligBlik.Application.Features.User.Commands;
using BoligBlik.Application.Features.User.Mapper;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Application.Interfaces.Users.Mappers;
using BoligBlik.Application.Interfaces.Users.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BoligBlik.Application.Extensions.User
{
    public static class UserServiceCollectionExtentions
    {
        public static IServiceCollection AddUsersService(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IUserCommandService, UserCommandService>();
            services.AddScoped<IUserQuerieService, IUserQuerieService>();

            //Mappers
            services.AddScoped<IUserDTOMapper, UserDTOMapper>();
            services.AddScoped<IUserMapper, UserMapper>();

            return services;
        }
    }
}
