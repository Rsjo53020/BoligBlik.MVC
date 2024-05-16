using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BoligBlik.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class BoardMemberConfiguration : IEntityTypeConfiguration<BoardMember>
    {
        public void Configure(EntityTypeBuilder<BoardMember> builder)
        {
            builder.ToTable("BoardMember", "boardMember");
            builder.HasKey(x => x.Id);
            builder.ComplexProperty(a => a.User);
        }
    }
}
