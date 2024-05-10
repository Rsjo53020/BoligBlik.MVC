using BoligBlik.Application.Interfaces;
using BoligBlik.Application.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using BoligBlik.Infrastructure.Services;
using IUserService = BoligBlik.Application.Interfaces.IUserService;

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
