using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Value;
using System.Reflection;
using BoligBlik.Persistence.Contexts.Seeder;

namespace BoligBlik.Persistence.Contexts
{
    public class BoligBlikContext : DbContext
    {
        //private readonly BoligblikSeeder _seeder;
        public BoligBlikContext(DbContextOptions<BoligBlikContext> options, BoligblikSeeder seeder) : base(options) { }

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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        // Add-Migration InitialMigration -Context BookingContext -Project BoligBlik.Persistence.Migrations
        // Update-Database -Context BookingContext -Project BoligBlik.Persistence.Migrations
    }
}
