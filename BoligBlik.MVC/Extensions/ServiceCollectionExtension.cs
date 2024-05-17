using AutoMapper;
using BoligBlik.MVC.Mappings;
using BoligBlik.MVC.ProxyServices.BoardMembers;
using BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces;

namespace BoligBlik.MVC.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddFrontEnd(this WebApplicationBuilder builder)
        {
            builder.AddHttpClients();
            builder.Services.AddServices();
            builder.Services.ConfigureMappers();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBoardMemberProxy, BoardMemberProxy>();
        }


        private static void AddHttpClients(this WebApplicationBuilder builder)
        {

            builder.Services.AddHttpClient("BaseClient", httpClient =>
            {
                httpClient.BaseAddress = new Uri(builder.Configuration["BaseAddress"]);
            });
        }

        private static void ConfigureMappers(this IServiceCollection services)
        {
            var mapProfiles = new List<Profile>()
            {
                new BoardMemberMappingProfile(),
                new UserMappingProfile(),
                new AddressMappingProfile()

            };

            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(mapProfiles);
            });
            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(typeof(Program));
        }
    }
}
