using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BoligBlik.Persistence.Contexts;
using BoligBlik.Persistence.Contexts.Interfaces;
using BoligBlik.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BoligBlik.Persistence.Repositories.BoardMembers;
using BoligBlik.Persistence.Repositories.Bookings;
using BoligBlik.Persistence.Repositories.Users;
using BoligBlik.Persistence.Repositories.Addresses;
using BoligBlik.Persistence.Repositories.BookingItems;

//using UserQuerieService = BoligBlik.Application.Features.User.Queries.UserQuerieService;


namespace BoligBlik.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();
            services.AddDbContext(configuration);

        }

        private static void AddRepositories(this IServiceCollection services)
        {

            services.AddTransient<IUnitOfWork, UnitOfWork>(p =>
            {
                var BoligBlikDb = p.GetService<BoligBlikContext>();
                var dbContext = p.GetService<DbContext>();
                return new UnitOfWork(BoligBlikDb);
            });

            //Booking Repo
            services.AddScoped<IBookingQuerieRepo, BookingQuerieRepo>();
            services.AddScoped<IBookingCommandRepo, BookingCommandRepo>();
            services.AddScoped<IBookingDomainService, BookingDomainService>();

            //Users
            services.AddScoped<IUserCommandRepo, UserCommandRepo>();
            services.AddScoped<IUserQuerieRepo, UserQuerieRepo>();

            //BoardMembers
            services.AddScoped<IBoardMemberCommandRepo, BoardMemberCommandRepo>();
            services.AddScoped<IBoardMemberQuerieRepo, BoardMemberQuerieRepo>();

            //Addresses
            services.AddScoped<IAddressCommandRepo, AddressCommandRepo>();
            services.AddScoped<IAddressQuerieRepo, AddressQuerieRepo>();

            //BookingItem
            services.AddScoped<IBookingItemCommandRepo, BookingItemCommandRepo>();
            services.AddScoped<IBookingItemQuerieRepo, BookingItemQuerieRepo>();

            //Database Seeder
            services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();
        }


        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("SkafteLocal") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //var connectionString = configuration.GetConnectionString("RSBackEndConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<BoligBlikContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }


    }
}
