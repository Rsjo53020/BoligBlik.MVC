using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ComplexProperty(a => a.Addresses);
        }
    }
}
