using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.DTO.Common;

namespace BoligBlik.MVC.DTO.Bookings
{
    public class BookingDTO : EntityDTO
    {
        public Guid AddressId { get; set; }
        public BookingItemDTO Item { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
