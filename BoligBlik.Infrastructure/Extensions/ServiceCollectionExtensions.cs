using BoligBlik.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BoligBlik.Infrastructure.Services;

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
            services.AddTransient<IMessageService, MessageService>();

            return services;
        }
    }
} 
