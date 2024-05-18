using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> entity)
        {
            entity.ToTable("Property", "property");
            entity.HasKey(x => x.Id);
            entity.Property(p => p.RowVersion)
                .IsRowVersion();
        }
    }
}
