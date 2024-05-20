using BoligBlik.MVC.DTO.Interfaces;
using BoligBlik.MVC.Models.Users;
using Microsoft.Build.Framework;

namespace BoligBlik.MVC.Models.Addresses
{
    public class AddressViewModel : IEntity
    {
        [Required]
        public Guid Id { get; set; }
        public string Street { get; set; }

        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }

        public string City { get; set; }
        //public string Country { get; set; }
        public string PostalCodeNumber { get; set; }
        public List<UserViewModel> Users { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
