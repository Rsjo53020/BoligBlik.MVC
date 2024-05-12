using BoligBlik.Application.Interfaces;
using BoligBlik.Application.Interfaces.Message;
using Microsoft.Extensions.DependencyInjection;
using BoligBlik.Infrastructure.Services.Message;

namespace BoligBlik.Infrastructure.Extensions
{

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();

            return services;
        }
    }
} 
