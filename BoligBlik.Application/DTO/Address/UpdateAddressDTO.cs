using BoligBlik.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Common.Entity;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Application.DTO.User;
using System.ComponentModel.DataAnnotations;

namespace BoligBlik.Application.DTO.Address
{
    public class UpdateAddressDTO : EntityDTO
    {
        [StringLength(100)]
        public string Street { get; set; }
        [StringLength(10)]
        public string HouseNumber { get; set; }
        [StringLength(25)]
        public string Floor { get; set; }
        [StringLength(10)]
        public string DoorNumber { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(10)]
        public string PostalCodeNumber { get; set; }
        public IEnumerable<UserDTO> Users { get; set; }
    }
}
