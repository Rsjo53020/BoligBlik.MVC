using AutoMapper;
using BoligBlik.Application.Common.Mappings;
using BoligBlik.Application.Features.BoardMembers.Commands;
using BoligBlik.Application.Features.BoardMembers.Queries;
using BoligBlik.Application.Features.Booking.Commands;
using BoligBlik.Application.Features.Booking.Queries;
using BoligBlik.Application.Features.Users.Commands;
using BoligBlik.Application.Features.Users.Queries;
using BoligBlik.Application.Interfaces.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.BoardMembers.Queries;
using BoligBlik.Application.Interfaces.Booking;
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
