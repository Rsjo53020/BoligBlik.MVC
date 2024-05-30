using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.DTO.Common;
using BoligBlik.MVC.Models.Addresses;
using BoligBlik.MVC.Models.BookingItems;
using BoligBlik.MVC.Models.Common;

namespace BoligBlik.MVC.Models.Bookings
{
    public class BookingViewModel : EntityViewModel
    {
        public Guid AddressId { get; set; }
        public BookingItemViewModel Item { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
