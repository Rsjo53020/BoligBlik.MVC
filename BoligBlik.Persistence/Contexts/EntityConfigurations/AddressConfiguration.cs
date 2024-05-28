using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BoligBlik.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Address", "address");
            entity.HasKey(x => x.Id);
            entity.HasMany(u => u.Users);
            entity.HasMany(b => b.Bookings);
            entity.ComplexProperty(a => a.PostalCode);
            entity.Property(p => p.RowVersion)
                .IsRowVersion();
        }
    }
}
