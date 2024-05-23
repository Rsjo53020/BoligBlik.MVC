using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.DTO.Common;
using BoligBlik.MVC.DTO.User;

namespace BoligBlik.MVC.DTO.Address
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
