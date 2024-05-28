using BoligBlik.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class BookingItemConfiguration : IEntityTypeConfiguration<BookingItem>
    {
        public void Configure(EntityTypeBuilder<BookingItem> builder)
        {
            builder.ToTable("BookingItem", "bookingItem");
            builder.HasKey(x => x.Id);
        }
    }
}
