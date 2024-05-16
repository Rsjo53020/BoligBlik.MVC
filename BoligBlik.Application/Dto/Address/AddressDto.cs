using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Application.DTO.Properties;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.Adress
{
    public class AddressDTO : IEntity
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public PostalCode PostalCode { get; set; }

        public IEnumerable<UserDTO> Users { get; set; }

        public IEnumerable<BookingDTO> Bookings { get; set; }

        public IEnumerable<PropertyDTO> Properties { get; set; }
        
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
