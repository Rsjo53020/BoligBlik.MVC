using BoligBlik.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payment", "payment");
            builder.HasKey(x => x.Id);
            builder.ComplexProperty(u => u.User);
        }
    }
}
