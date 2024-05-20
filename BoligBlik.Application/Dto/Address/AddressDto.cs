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
using BoligBlik.Application.DTO.PostalCodes;

namespace BoligBlik.Application.DTO.Address
{
    public class AddressDTO : IEntity
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }

        public string City { get; set; }

        public string PostalCodeNumber { get; set; }

        //public PostalCodeDTO PostalCode { get; set; }

        //public List<UserDTO> Users { get; set; }

        //public List<BookingDTO> Bookings { get; set; }

        //public List<PropertyDTO> Properties { get; set; }
        
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
