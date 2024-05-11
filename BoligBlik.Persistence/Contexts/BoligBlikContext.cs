using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Persistence.Contexts
{
    public class BoligBlikContext : DbContext
    {
        public BoligBlikContext(DbContextOptions<BoligBlikContext> options) : base(options) { }

        public DbSet<BoardMember> BoardMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new BookingConfirguration());
        }
    }
}
