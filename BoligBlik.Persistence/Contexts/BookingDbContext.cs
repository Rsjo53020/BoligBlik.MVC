using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Value;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BoligBlik.Persistence.Contexts.EntityConfigurations;


namespace BoligBlik.Persistence.Contexts
{
    public class BookingDbContext : DbContext
    {

        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BookingConfirguration());
        }

        public BookingDbContext() { }
        //public DbSet<BookingDates> BookingDates { get; set; }

        //public DbSet<Address> Addresses { get; set; }
        //public DbSet<PostalCode> PostalCodes { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<Item> Items { get; set; }

        //public DbSet<Payment> Payments { get; set; }




    }


    // Add-Migration InitialMigration -Context BookingContext -Project BoligBlik.Persistence.Migrations
    // Update-Database -Context BookingContext -Project BoligBlik.Persistence.Migrations
}
