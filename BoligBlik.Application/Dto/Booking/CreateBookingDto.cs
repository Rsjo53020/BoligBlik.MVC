using BoligBlik.Application.Dto.Ithem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Dto.Booking
{

    public class CreateBookingDto
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
        }
}
