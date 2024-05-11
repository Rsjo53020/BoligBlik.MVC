using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BoligBlik.Persistence.Contexts;
using BoligBlik.Persistence.Repositories;
using BoligBlik.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BoligBlik.Infrastructure.Services;
using BoligBlik.Application.Interfaces.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.BoardMembers.Queries;
using BoligBlik.Persistence.Repositories.Commands;
using BoligBlik.Persistence.Repositories.Queries;


namespace BoligBlik.Persistence.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories();
            services.AddDbContext(configuration);

            //BoardMembers
            services.AddScoped<IBoardMemberCommandRepo, BoardMemberCommandRepo>();
            services.AddScoped<IBoardMemberQuerieRepo, BoardMemberQuerieRepo>();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookingDomainService, BookingDomainService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>(p =>
            {
                var db = p.GetService<BookingDbContext>();
                return new UnitOfWork(db);
            });
            services.AddScoped<IBookingRepo, BookingRepo>();

            services.AddScoped<IUserRepo, UserRepo>();


        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<BookingDbContext>(options =>
                options.UseSqlServer(connectionString,
                    builder => builder.MigrationsAssembly(typeof(BookingDbContext).Assembly.FullName)));

            services.AddDbContext<BoligBlikContext>(options =>
                options.UseSqlServer(connectionString,
                    builder => builder.MigrationsAssembly(typeof(BoligBlikContext).Assembly.FullName)));
        }


    }
}
