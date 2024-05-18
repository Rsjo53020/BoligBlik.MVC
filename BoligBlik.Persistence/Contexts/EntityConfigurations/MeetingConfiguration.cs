using BoligBlik.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class MeetingConfiguration : IEntityTypeConfiguration<Meeting> 
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder.ToTable("Meeting", "meeting");
            builder.HasKey(x => x.Id);
           
        }
    }
}
