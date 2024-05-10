using BoligBlik.Application.Features.User.Commands;
using BoligBlik.Application.Features.User.Commands.Interfaces;
using BoligBlik.Application.Features.User.Queries;
using BoligBlik.Application.Features.User.Queries.Interfaces;

using BoligBlik.Persistence.Extensions;
using BoligBlik.Infrastructure.Extensions;
using BoligBlik.Infrastructure.Extensions;


namespace BoligBlik.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddPersistenceLayer(builder.Configuration);
            builder.Services.AddInfrastructureLayer();
            builder.Services.AddControllers();






            // Learn more about configuing Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IUserCreate, UserCreate>();
            builder.Services.AddScoped<IUserGet, UserGet>();
            builder.Services.AddScoped<IUserGetAll, UserGetAll>();
            builder.Services.AddScoped<IUserUpdate, UserUpdate>();
            builder.Services.AddScoped<IUserDelete, UserDelete>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
