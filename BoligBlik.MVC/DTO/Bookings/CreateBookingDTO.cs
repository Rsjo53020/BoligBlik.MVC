using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BookingItems;

namespace BoligBlik.MVC.DTO.Bookings
{
    public class CreateBookingDTO
    {
        public BookingItemDTO Item { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
