using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }

    // Add-Migration InitialMigration -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration
    // Update-Database -Context BookMyHomeContext -Project BookMyHome.DatabaseMigration
}
