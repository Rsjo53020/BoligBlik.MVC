using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Value;
using BoligBlik.Persistence.Contexts.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.Persistence.Contexts
{
    public class AddressDbContext : DbContext
    {
        public AddressDbContext(DbContextOptions<AddressDbContext> options) : base(options)
        {

        }
        
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new AddressConfirguration());
        }
    }
}
