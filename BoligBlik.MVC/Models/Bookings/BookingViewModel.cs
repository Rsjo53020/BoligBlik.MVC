using BoligBlik.MVC.Models.BookingItems;

namespace BoligBlik.MVC.Models.Bookings
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Approved { get; set; }
        public Guid ItemId { get; set; }
        public IEnumerable<BookingItemViewModel> Item { get; set; }
        public Guid AddressId { get; set; }
    }
}
