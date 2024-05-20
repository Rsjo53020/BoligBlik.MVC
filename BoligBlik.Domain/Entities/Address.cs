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
        public IReadOnlyList<User> Users => _user.AsReadOnly();
        private List<User> _user = new();
        public IReadOnlyList<Booking>? Bookings => _bookings.AsReadOnly();
        private List<Booking> _bookings = new();

        internal Address()
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
