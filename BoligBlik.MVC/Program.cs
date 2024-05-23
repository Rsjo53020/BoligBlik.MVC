using BoligBlik.MVC.Data;
using BoligBlik.MVC.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BoligBlik.MVC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container -- move to a ServiceExtension.cs
            var connectionString = builder.Configuration
                .GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
                //.GetConnectionString("AlexFrontEndLocalConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            // move to a ServiceExtension.cs
            builder.Services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString));

            // move to a ServiceExtension.cs
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            //flyt til en ServiceExtension.cs (identities) 
            builder.Services.AddDefaultIdentity<IdentityUser>(
                    options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            builder.AddFrontEnd();



            //// move to a ServiceExtension.cs
            //builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            //    {
            //        options.Password.RequiredUniqueChars = 0;
            //        options.Password.RequireUppercase = false;
            //        options.Password.RequiredLength = 8;
            //        options.Password.RequireNonAlphanumeric = false;
            //        options.Password.RequireDigit = false;
            //        options.Password.RequireLowercase = false;
            //    })
            //    .AddEntityFrameworkStores<ApplicationDbContext>();



            builder.Services.AddControllersWithViews();


            // move to a ServiceExtension.cs
            builder.Services.AddAuthorization(options => options
                .AddPolicy("ManagementPolicy", policyBuilder => policyBuilder.RequireClaim("Admin")));
            builder.Services.AddAuthorization(options => options
                .AddPolicy("MemberPolicy", policyBuilder => policyBuilder.RequireClaim("Member")));

            // Add more claims as necessary

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

            //using (var scope = app.Services.CreateScope())
            //{
            //    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //    var roles = new[] { "Admin", "Manager", "Member" };

            //    foreach (var role in roles)
            //    {
            //        if (!await roleManager.RoleExistsAsync(role))
            //            await roleManager.CreateAsync(new IdentityRole(role));

            //    }

            //}

            app.Run();
        }
    }
}