using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BoligBlik.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address", "address");
            builder.HasKey(x => x.Id);
            //builder.ComplexProperty(a => a.Users);
            //builder.ComplexProperty(a => a.Properties);
            //builder.ComplexProperty(a => a.Bookings);
            builder.ComplexProperty(a => a.PostalCode);
        }
    }
}
