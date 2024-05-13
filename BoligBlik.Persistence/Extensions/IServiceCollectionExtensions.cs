using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Application.Interfaces.Users.Queries;
using BoligBlik.Domain.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BoligBlik.Persistence.Contexts;
using BoligBlik.Persistence.Repositories;
using BoligBlik.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BoligBlik.Infrastructure.Services;
using BoligBlik.Persistence.Repositories.BoardMembers;
using BoligBlik.Persistence.Repositories.Users;

namespace BoligBlik.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Constructor AddPersistenceLayer, Configure calling methods. 
        /// </summary>
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            AddRepositories(services);
            AddDbContext(services, configuration);

            AddBoardMembers(services);
            AddBookings(services);
            AddUsers(services);
        }

        /// <summary>
        /// This Method Configure Services and Repositories for BoardMembers
        /// </summary>
        private static void AddBoardMembers(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IBoardMemberCommandRepo, BoardMemberCommandRepo>();
            services.AddScoped<IBoardMemberQuerieRepo, BoardMemberQuerieRepo>();
        }

        /// <summary>
        /// This Method Configure Services and Repositories for Users
        /// </summary>
        private static void AddUsers(this IServiceCollection services)
        {
            //Repositories 
            services.AddScoped<IUserCommandRepo, UserCommandRepo>();
            services.AddScoped<IUserQuerieRepo, UserQuerieRepo>();
        }

        /// <summary>
        /// This Method Configure Services and Repositories for Bookings
        /// </summary>
        private static void AddBookings(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IBookingDomainService, BookingDomainService>();

            //Repositories 
            services.AddScoped<IBookingRepo, BookingRepo>();
        }

        /// <summary>
        /// This Method Configure Services for Repositories
        /// </summary>
        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>(p =>
            {
                var db = p.GetService<BoligBlikContext>();
                return new UnitOfWork(db);
            });
        }

        /// <summary>
        /// This Method Configure Services for DbContext
        /// </summary>
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<BoligBlikContext>(options =>
                options.UseSqlServer(connectionString,
                    builder => builder.MigrationsAssembly(typeof(BoligBlikContext).Assembly.FullName)));
        }
    }
}
