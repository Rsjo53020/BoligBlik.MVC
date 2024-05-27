using System.ComponentModel.DataAnnotations;
using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Addresses;
using BoligBlik.MVC.Models.BookingItems;
using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Models.Bookings
{
    public class CreateBookingViewModel
    {
        public AddressViewModel Address { get; set; }

        public BookingItemViewModel BookingItem { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}