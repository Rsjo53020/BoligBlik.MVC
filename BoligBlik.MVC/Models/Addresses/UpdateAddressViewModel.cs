using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Common;
using System.ComponentModel.DataAnnotations;
using BoligBlik.MVC.DTO.Bookings;

namespace BoligBlik.MVC.Models.Addresses
{
    public class UpdateAddressViewModel : EntityViewModel
    {
        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string Floor { get; set; }

        public string DoorNumber { get; set; }

        public string City { get; set; }

        public string PostalCodeNumber { get; set; }

        public IReadOnlyCollection<IEnumerable<UserDTO>> Users { get ; set; }
        //?? new List<AddressDTO>()
        public IReadOnlyCollection<IEnumerable<BookingDTO>> Bookings { get; set; }

    }
}
