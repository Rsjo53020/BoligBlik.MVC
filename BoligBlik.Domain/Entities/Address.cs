using BoligBlik.Domain.Common.Shared;
using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Value;

namespace BoligBlik.Entities
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Floor { get; set; }
        public string DoorNumber { get; set; }
        public PostalCode PostalCode { get; set; }
        public List<User> Users { get; set; }

        private List<Booking> Bookings { get; set; }

        public Address()
        {

        }

        public Address(string street, string houseNumber, string floor, string doorNumber, string city, string postalCodeNumber)
        {
            Street = street;
            HouseNumber = houseNumber;
            Floor = floor;
            DoorNumber = doorNumber;
            PostalCode = new PostalCode(city, postalCodeNumber);
        }
    }
}
