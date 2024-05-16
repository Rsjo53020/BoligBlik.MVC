using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "user");
            builder.HasKey(x => x.Id);
            builder.ComplexProperty(a => a.Address);
        }
    }
}
