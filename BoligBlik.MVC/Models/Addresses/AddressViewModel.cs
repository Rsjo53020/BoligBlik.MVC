using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Models.Addresses
{
    public class AddressViewModel
    {
        public string Street { get; set; }

        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }

        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public List<UserViewModel> Users { get; set; }
    }
}
