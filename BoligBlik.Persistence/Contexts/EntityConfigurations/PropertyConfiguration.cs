using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property", "property");
            builder.HasKey(x => x.Id);
            builder.ComplexProperty(a => a.Addresses);
            builder.ComplexProperty(a => a.BoardMember);
        }
    }
}
