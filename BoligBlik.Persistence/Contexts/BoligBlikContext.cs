using BoligBlik.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BoligBlik.Entities;
using BoligBlik.Persistence.Contexts.EntityConfigurations;

namespace BoligBlik.Persistence.Contexts
{
    public class BoligBlikContext : DbContext
    {
        public BoligBlikContext(DbContextOptions<BoligBlikContext> options) : base(options)
        {
        }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<BookingItem> BookingItems { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this will apply configs from separate classes which implemented IEntityTypeConfiguration<T>
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfirguration());


        }

        // Add-Migration InitialMigration -Context BoligBlikContext -Project BoligBlik.Persistence.Migrations
        // Update-Database -Context BoligBlikContext -Project BoligBlik.Persistence.Migrations



    }

}
