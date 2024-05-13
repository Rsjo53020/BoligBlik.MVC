using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BoligBlik.Domain.Value;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoligBlik.Persistence.Contexts.EntityConfigurations
{
    public class AddressConfirguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ComplexProperty(p => p.PostalCode);
        }
    }
}
