using BoligBlik.MVC.Data;
using BoligBlik.MVC.Extensions;
using BoligBlik.MVC.ProxyServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BoligBlik.MVC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            var connectionString = builder.Configuration
                .GetConnectionString("AlexFrontEndLocalConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                .GetConnectionString("RSConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                /*.GetConnectionString("SkafteFrontEndLocal") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");*/

            // Adding DbContext service
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString));

            // Adding developer page exception filter
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // Adding identity services
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(
                    options =>
                    {
                        options.Password.RequiredUniqueChars = 0;
                        options.Password.RequireUppercase = false;
                        options.Password.RequiredLength = 8;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireLowercase = false;
                    })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add ServiceCollection
            builder.AddFrontEnd();

            // Adding Razor Pages service
            builder.Services.AddRazorPages();

            // Adding MVC services with controllers and views
            builder.Services.AddControllersWithViews();

            // Adding authorization policies
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ManagementPolicy", policyBuilder => policyBuilder.RequireClaim("Admin"));
                options.AddPolicy("MemberPolicy", policyBuilder => policyBuilder.RequireClaim("Member"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            // Uncomment and use this block if you need to seed roles
            // using (var scope = app.Services.CreateScope())
            // {
            //     var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //     var roles = new[] { "Admin", "Manager", "Member" };
            //     foreach (var role in roles)
            //     {
            //         if (!await roleManager.RoleExistsAsync(role))
            //             await roleManager.CreateAsync(new IdentityRole(role));
            //     }
            // }

            app.Run();
        }
    }
}
