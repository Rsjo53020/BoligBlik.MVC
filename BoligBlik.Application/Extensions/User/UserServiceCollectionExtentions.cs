using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Features.User;
using BoligBlik.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BoligBlik.Application.Extensions.User
{
    public static class UserServiceCollectionExtentions
    {
        public static IServiceCollection AddUsersService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
