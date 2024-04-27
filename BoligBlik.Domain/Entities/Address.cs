using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Value;

namespace BoligBlik.Domain.Entities
{
    public class Address
    {
        [Key]
        public Guid DAWAId { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public PostalCode PostalCode { get; set; }
    }
}
