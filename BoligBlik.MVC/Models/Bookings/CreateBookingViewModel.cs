using BoligBlik.MVC.Models.BookingItems;

namespace BoligBlik.MVC.Models.Bookings
{
    public class CreateBookingViewModel
    {
        public Guid AddressId { get; set; }
        public BookingItemViewModel Item { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}