using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Value;

namespace BoligBlik.Domain.Value
{
    public record Address(Guid DAWAId, string Street, string HouseNumber, string Floor, string DoorNumber,
        PostalCode PostalCode);

}
