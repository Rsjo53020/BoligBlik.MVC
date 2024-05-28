using BoligBlik.Application.DTO.Address;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.Bookings
{
    public class CreateBookingDTO
    {
 
        public BookingItemDTO Item { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
