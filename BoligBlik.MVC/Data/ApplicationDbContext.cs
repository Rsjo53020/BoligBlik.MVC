using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BoligBlik.MVC.Models.Addresses;

namespace BoligBlik.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<BoligBlik.MVC.Models.Addresses.AddressViewModel> AddressViewModel { get; set; } = default!;
    }



    // Add-Migration InitialMigration -Context ApplicationDbContext -Project Boligblik.DatabaseMigration
    // Update-Database -Context ApplicationDbContext -Project BoligBlik.Persistence
}
