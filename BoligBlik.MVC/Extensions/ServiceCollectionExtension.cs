using AutoMapper;
using BoligBlik.MVC.Data;
using BoligBlik.MVC.Features.Documents;
using BoligBlik.MVC.Features.Documents.Interfaces;
using BoligBlik.MVC.Mappings;
using BoligBlik.MVC.ProxyServices.Addresses;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;
using BoligBlik.MVC.ProxyServices.BoardMembers;
using BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces;
using BoligBlik.MVC.ProxyServices.BookingItems;
using BoligBlik.MVC.ProxyServices.BookingItems.Interfaces;
using BoligBlik.MVC.ProxyServices.Bookings;
using BoligBlik.MVC.ProxyServices.Bookings.Interfaces;
using BoligBlik.MVC.ProxyServices.Users;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.MVC.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddFrontEnd(this WebApplicationBuilder builder)
        {
            AddHttpClients(builder);
            AddServices(builder.Services);
            ConfigureMappers(builder.Services);
            AddDbContext(builder);
            Identities(builder);
            AddAuthorization(builder);
        }

        /// <summary>
        /// IoC
        /// </summary>
        /// <param name="services"></param>
        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBoardMemberProxy, BoardMemberProxy>();
            services.AddTransient<IAddressProxy, AddressProxy>();
            services.AddTransient<IUserProxy, UserProxy>();
            services.AddTransient<IDocumentService, DocumentService>();
            services.AddTransient<IBookingItemsProxy, BookingItemsProxy>();
            services.AddTransient<IBookingProxy, BookingProxy>();
        }

        /// <summary>
        /// Creates a named client with URI form appsettings
        /// </summary>
        /// <param name="builder"></param>
        private static void AddHttpClients(this WebApplicationBuilder builder)
        {

            builder.Services.AddHttpClient("BaseClient", httpClient =>
            {
                httpClient.BaseAddress = new Uri(builder.Configuration["BaseAddress"]);
            });
        }
        /// <summary>
        /// FrontEnd IMapper Collection
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureMappers(this IServiceCollection services)
        {
            var mapProfiles = new List<Profile>()
            {
                new BoardMemberMappingProfile(),
                new UserMappingProfile(),
                new AddressMappingProfile(),
                new BookingMappingProfile(),
                new BookingItemMappingProfile()
            };

            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(mapProfiles);
            });
            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(typeof(Program));
        }

        /// <summary>
        /// AddDbContext. 4x ConnectionString 
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="InvalidOperationException"></exception>
        private static void AddDbContext(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration
                .GetConnectionString("DefaultConnection")
                                   ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //.GetConnectionString("RSFrontEndConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //.GetConnectionString("AlexFrontEndLocalConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");


            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString));


        }
        /// <summary>
        /// Identities Role set
        /// </summary>
        /// <param name="builder"></param>
        private static void Identities(this WebApplicationBuilder builder)
        {
            //flyt til en ServiceExtension.cs (identities) 
            builder.Services.AddDefaultIdentity<IdentityUser>(
                    options =>
                    {
                        //options.Password.RequiredUniqueChars = 0;
                        //options.Password.RequireUppercase = false;
                        //options.Password.RequiredLength = 8;
                        //options.Password.RequireNonAlphanumeric = false;
                        //options.Password.RequireDigit = false;
                        //options.Password.RequireLowercase = false;
                        options.SignIn.RequireConfirmedAccount = true;
                    })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
        }

        /// <summary>
        /// AddAuthorizationPolicy
        /// </summary>
        /// <param name="builder"></param>
        private static void AddAuthorization(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options => options
                .AddPolicy("ManagementPolicy", policyBuilder => policyBuilder.RequireClaim("Admin", "Formand", "Admin")));
            builder.Services.AddAuthorization(options => options
                .AddPolicy("MemberPolicy", policyBuilder => policyBuilder.RequireClaim("Boardmembers")));
        }
    }
}
