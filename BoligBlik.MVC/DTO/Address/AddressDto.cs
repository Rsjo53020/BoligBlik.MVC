using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.DTO.Interfaces;
using BoligBlik.MVC.DTO.PostalCodes;
using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.DTO.Properties;

namespace BoligBlik.MVC.DTO.Address
{
    public class AddressDTO : IEntity
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public PostalCodeDTO PostalCode { get; set; }

        public List<UserDTO> Users { get; set; }

        public List<BookingDTO> Bookings { get; set; }

        public List<PropertyDTO> Properties { get; set; }

        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
