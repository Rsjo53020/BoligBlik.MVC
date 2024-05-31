using BoligBlik.MVC.Models.Bookings;
using BoligBlik.MVC.Models.Common;
using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Models.Addresses
{
    public class AddressViewModel : EntityViewModel
    {

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string Floor { get; set; }

        public string DoorNumber { get; set; }

        public string City { get; set; }

        public string PostalCodeNumber { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<BookingViewModel> Bookings { get; set; }
    }
}
