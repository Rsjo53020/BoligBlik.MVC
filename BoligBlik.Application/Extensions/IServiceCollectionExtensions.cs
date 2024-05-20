using AutoMapper;
using BoligBlik.Application.Common.Mappings;
using BoligBlik.Application.Features.Addresses.Commands;
using BoligBlik.Application.Features.Addresses.Queries;
using BoligBlik.Application.Features.BoardMembers.Commands;
using BoligBlik.Application.Features.BoardMembers.Queries;
using BoligBlik.Application.Features.BookingItems.Commands;
using BoligBlik.Application.Features.BookingItems.Queries;
using BoligBlik.Application.Features.Bookings.Commands;
using BoligBlik.Application.Features.Bookings.Queries;
using BoligBlik.Application.Features.Users.Commands;
using BoligBlik.Application.Features.Users.Queries;
using BoligBlik.Application.Interfaces.Addresses.Commands;
using BoligBlik.Application.Interfaces.Addresses.Queries;
using BoligBlik.Application.Interfaces.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.BoardMembers.Queries;
using BoligBlik.Application.Interfaces.BookingItems.Commands;
using BoligBlik.Application.Interfaces.BookingItems.Queries;
using BoligBlik.Application.Interfaces.Bookings;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Application.Interfaces.Users.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace BoligBlik.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            //Add features
            AddBoardMember(services);
            AddUsersService(services);
            AddBooking(services);
            AddAddresses(services);
            AddBookingItems(services);

            ConfigureMappers(services);
        }




        /// <summary>
        /// configure mappers for automappers
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureMappers(this IServiceCollection services)
        {
            var mapProfiles = new List<Profile>()
            { 
                new AddressMappingProfile(),
                new AddressMappingProfile(),
                new BoardMemberMappingProfile(),
                new BookingItemMappingProfile(),
                new BookingItemMappingProfile(),
                new PaymentMappingProfile(),
                new UserMappingProfiles()
            };

            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(mapProfiles);
            });
            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void Domain(this IServiceCollection services)
        {
            services.AddScoped<IBookingItemCommandService, BookingItemCommandService>();
            services.AddScoped<IBookingItemQuerieService, BookingItemQuerieService>();
        }

        private static void AddBookingItems(this IServiceCollection services)
        {
            services.AddScoped<IBookingItemCommandService, BookingItemCommandService>();
            services.AddScoped<IBookingItemQuerieService, BookingItemQuerieService>();
        }

        private static void AddAddresses(this IServiceCollection services)
        {
            services.AddScoped<IAddressCommandService, AddressCommandService>();
            services.AddScoped<IAddressQuerieService, AddressQuerieService>();
        }

        private static void AddBooking(this IServiceCollection services)
        {
            services.AddScoped<IBookingCommandService, BookingCommandService>();
            services.AddScoped<IBookingQuerieService, BookingQueriesServices>();
        }
        private static void AddBoardMember(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IBoardMemberCommandService, BoardMemberCommandService>();
            services.AddScoped<IBoardMemberQuerieService, BoardMemberQuerieService>();
        }
        private static void AddUsersService(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IUserCommandService, UserCommandService>();
            services.AddScoped<IUserQuerieService, UserQueriesService>();
        }
    }
}
