using BoligBlik.Application.Interfaces.Message;
using Microsoft.Extensions.DependencyInjection;
using BoligBlik.Infrastructure.Services.Message;
using BoligBlik.Application.Interfaces.Infrastructure;
using BoligBlik.Infrastructure.Services.Addresses;

namespace BoligBlik.Infrastructure.Extensions
{

    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            AddServices(services);
            HttpClientFactory (services);
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
        }

        private static void HttpClientFactory (this IServiceCollection services)
        {
            services.AddScoped<IAddressValidationInf, AddressValidationInf>();
        }
    }
}
