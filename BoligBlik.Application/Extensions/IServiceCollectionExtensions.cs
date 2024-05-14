using AutoMapper;
using BoligBlik.Application.Common.Mappings;
using BoligBlik.Application.Features.Addresses.Commands;
using BoligBlik.Application.Features.Addresses.Queries;
using BoligBlik.Application.Features.BoardMembers.Commands;
using BoligBlik.Application.Features.BoardMembers.Queries;
using BoligBlik.Application.Features.Bookings.Commands;
using BoligBlik.Application.Features.Bookings.Queries;
using BoligBlik.Application.Features.Users.Commands;
using BoligBlik.Application.Features.Users.Queries;
using BoligBlik.Application.Interfaces.Addresses.Commands;
using BoligBlik.Application.Interfaces.Addresses.Queries;
using BoligBlik.Application.Interfaces.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.BoardMembers.Queries;
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
        }

        private static void AddAddresses(this IServiceCollection services)
        {
            services.AddScoped<IAddressCommandService, AddressCommandService>();
            services.AddScoped<IAddressQuerieService, AddressQuerieService>();
            ConfigureAddressMappers(services);
        }
        private static void ConfigureAddressMappers(this IServiceCollection services)
        {
            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AddressMappingProfile());
            });
            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        private static void AddBooking(this IServiceCollection services)
        {
            services.AddScoped<IBookingCommandService, BookingCommandService>();
            services.AddScoped<IBookingQuerieService, BookingQueriesServices>();

            ConfigureBookingMappers(services);
        }
        private static void ConfigureBookingMappers(this IServiceCollection services)
        {
            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BookingMappingProfiles());
            });
            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        private static void AddBoardMember(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IBoardMemberCommandService, BoardMemberCommandService>();
            services.AddScoped<IBoardMemberQuerieService, BoardMemberQuerieService>();
            ConfigureBoardMemberMappers(services);
        }
        private static void ConfigureBoardMemberMappers(this IServiceCollection services)
        {
            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BoardMemberMappingProfile());
            });

            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
        private static void AddUsersService(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IUserCommandService, UserCommandService>();
            services.AddScoped<IUserQuerieService, UserQueriesService>();
            ConfigureUserMappers(services);
        }
        private static void ConfigureUserMappers(this IServiceCollection services)
        {
            var mapConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserMappingProfiles());
            });
            IMapper mapper = mapConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
