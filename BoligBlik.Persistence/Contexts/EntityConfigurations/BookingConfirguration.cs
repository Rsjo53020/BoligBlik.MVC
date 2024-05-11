using BoligBlik.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class BookingConfirguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking", "booking");
            builder.HasKey(i => i.Id);
            builder.HasOne(a => a.BookingDates);

        }
    }
}
