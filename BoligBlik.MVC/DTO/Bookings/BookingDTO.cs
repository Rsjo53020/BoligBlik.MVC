using System.ComponentModel.DataAnnotations;
using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.DTO.BookingItems;

namespace BoligBlik.MVC.DTO.Bookings
{
    public class BookingDTO
    {
        [Required]
        public Guid Id { get; set; }
        public DateOnly creationDate { get; set; }
        [Required]
        public  DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public bool Approved { get; set; }

        [Required]
        public Guid ItemId { get; set; }

        public IEnumerable<BookingItemDTO> Item { get; set; }

        [Required]
        public Guid AddressId { get; set; }
    }

    
}
