using BoligBlik.Persistence.Extensions;
using BoligBlik.Infrastructure.Extensions;
using BoligBlik.Application.Extensions;
using BoligBlik.Persistence.Contexts;
using BoligBlik.Persistence.Contexts.Interfaces;

namespace BoligBlik.WebAPI
{
    /// <summary>
    /// BoligBlik.API Startup
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddPersistenceLayer(builder.Configuration);
            builder.Services.AddInfrastructureLayer();
            builder.Services.AddApplicationLayer();
            builder.Services.AddAutoMapper(typeof(StartupBase));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //DAWA API Configuration
            builder.Services.AddHttpClient("AddressValidationClient", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration
                                                 .GetSection("ClientAddresses")
                                                 .GetValue<string>("DAWAApi")
                                             ?? throw new MissingFieldException("Missing the api client url"));
            });

            var app = builder.Build();

            //
            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<BoligBlikContext>().Database.EnsureCreated();
            }

            if (app.Environment.IsDevelopment())
            {
                //Seed the Database
                var serviceProvider = builder.Services.BuildServiceProvider();
                var seeder = serviceProvider.GetService<IDatabaseSeeder>();
                seeder.SeedDB();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
