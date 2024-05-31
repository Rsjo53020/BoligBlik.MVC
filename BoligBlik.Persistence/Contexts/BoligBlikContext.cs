using BoligBlik.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BoligBlik.Entities;
using BoligBlik.Persistence.Contexts.EntityConfigurations;

namespace BoligBlik.Persistence.Contexts
{
    public class BoligBlikContext : DbContext
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="options"></param>
        public BoligBlikContext(DbContextOptions<BoligBlikContext> options) : base(options)
        {
        }

        /// <summary>
        /// Database Context for Entity Framework
        /// </summary>
        public DbSet<Address> Adresses { get; set; }
        public DbSet<BoardMember> BoardMembers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingItem> BookingItems { get; set; }
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Configure Complex Entities for Database
        /// </summary>
        /// <param name="modelBuilder"></param>
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
