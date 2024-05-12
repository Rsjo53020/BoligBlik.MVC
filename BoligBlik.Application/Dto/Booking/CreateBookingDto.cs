using BoligBlik.Application.DTO.Ithem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.DTO.Booking
{

    public class CreateBookingDTO
    {
        //[Required]
        //public Guid AddressId { get; set; }
        //public Guid UserId { get; set; }
        //public Guid IthemId { get; set; }

        [Required] 
        public DateOnly CreationDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        public bool Approved { get; set; }

        public byte[] RowVersion { get; set; } = new byte[10];
    }
}
