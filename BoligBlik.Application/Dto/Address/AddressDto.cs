using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Common.Entity;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Application.DTO.Address
{
    public class AddressDTO : EntityDTO
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }

        public string City { get; set; }

        public string PostalCodeNumber { get; set; }

        public IEnumerable<UserDTO> Users { get; set; }

        public IEnumerable<BookingDTO> Bookings { get; set; }
    }
}
