using System.ComponentModel.DataAnnotations;

namespace BoligBlik.MVC.DTO.Bookings
{

    public class CreateBookingDTO
    {
        [Required]
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }

        [Required] 
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        public bool Approved { get; set; }

        public byte[] RowVersion { get; set; } = [];
    }
}
