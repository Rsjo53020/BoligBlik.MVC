using BoligBlik.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BoligBlik.Infrastructure.Services;

namespace BoligBlik.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IMessageService, MessageService>();
        }
    }
}
