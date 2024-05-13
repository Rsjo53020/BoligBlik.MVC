using BoligBlik.Application.Features.Booking.Queries;
using BoligBlik.Application.Interfaces.Booking;
using BoligBlik.Application.Interfaces.Message;
using Microsoft.Extensions.DependencyInjection;
using BoligBlik.Infrastructure.Services.Message;
using BoligBlik.Application.Features.User.Commands;
using BoligBlik.Application.Features.User.Mapper;
using BoligBlik.Application.Features.User.Queries;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Application.Interfaces.Users.Mappers;
using BoligBlik.Application.Interfaces.Users.Queries;

namespace BoligBlik.Infrastructure.Extensions
{

    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();

            //Booking - Services
            services.AddScoped<IBookingQuerieService, BookingQueriesServices>();


            // User - Services
            services.AddScoped<IUserCommandService, UserCommandService>();
            //UserQuerieService add fejl i tidl. kode og koden fremgår to steder
            services.AddScoped<IUserQuerieService, UserQuerieService>();

            //User Mappers
            services.AddScoped<IUserDTOMapper, UserDTOMapper>();
            services.AddScoped<IUserMapper, UserMapper>();


        }
    }
} 
