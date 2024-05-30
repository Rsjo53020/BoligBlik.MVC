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

        public List<Booking> Bookings { get; set; }

        /// <summary>
        /// Constructor used for Entity Framework.
        /// </summary>
        public Address() { }

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="street"></param>
        /// <param name="houseNumber"></param>
        /// <param name="floor"></param>
        /// <param name="doorNumber"></param>
        /// <param name="city"></param>
        /// <param name="postalCodeNumber"></param>
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
