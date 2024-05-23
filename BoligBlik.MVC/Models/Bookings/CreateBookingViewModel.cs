using System.ComponentModel.DataAnnotations;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.BookingItems;

namespace BoligBlik.MVC.Models.Bookings
{
    public class CreateBookingViewModel
    {
        public UserDTO user { get; set; }

        public Guid ItemId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public byte[] RowVersion { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}