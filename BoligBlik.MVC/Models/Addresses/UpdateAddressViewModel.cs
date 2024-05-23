using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Common;

namespace BoligBlik.MVC.Models.Addresses
{
    public class UpdateAddressViewModel : EntityViewModel
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public string PostalCodeNumber { get; set; }
        public string City { get; set; }

        public IEnumerable<UserDTO> Users { get; set; }
    }
}
