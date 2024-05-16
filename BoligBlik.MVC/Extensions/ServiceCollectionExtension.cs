using BoligBlik.MVC.ProxyServices.BoardMembers;
using BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces;

namespace BoligBlik.MVC.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddFrontEnd(this WebApplicationBuilder builder)
        {
            builder.AddHttpClients();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBoardMemberServices, BoardMemberServices>();
        }


        private static void AddHttpClients(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<BoardMemberServices>(client =>
            {
                var apiBaseAddress = builder.Configuration["BaseAddress"];
                client.BaseAddress = new Uri(apiBaseAddress);
            });
        }
    }
}
