using BoligBlik.Application.Features.Bookings.Queries;
using BoligBlik.Application.Interfaces.Bookings;
using BoligBlik.Application.Interfaces.Message;
using Microsoft.Extensions.DependencyInjection;
using BoligBlik.Infrastructure.Services.Message;
using BoligBlik.Application.Features.Users.Commands;
using BoligBlik.Application.Features.Users.Queries;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Application.Interfaces.Users.Queries;

namespace BoligBlik.Infrastructure.Extensions
{

    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
        }
    }
} 
