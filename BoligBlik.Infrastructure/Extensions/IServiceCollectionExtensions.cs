using Microsoft.Extensions.DependencyInjection;
using BoligBlik.Domain.Common.Interfaces;

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
            
        }
    }
}
