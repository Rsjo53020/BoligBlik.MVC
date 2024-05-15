using BoligBlik.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class BookingConfirguration : IEntityTypeConfiguration<Booking>  
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ComplexProperty(b => b.BookingDates);
            builder.ComplexProperty(a => a.Address);

        }
    }
}
