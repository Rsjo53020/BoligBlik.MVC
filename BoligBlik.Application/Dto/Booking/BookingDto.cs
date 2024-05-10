using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Dto.Ithem;

namespace BoligBlik.Application.Dto.Booking
{
    public class BookingDto
    {
        [Required]
        public Guid Id { get; set; }
        public DateOnly creationDate { get; set; }
        [Required]
        public  DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public bool Approved { get; set; }

        //[Required]
        //public Guid ItemId { get; set; } 

        //public IEnumerable<ItemDto> Item { get; set; }

        //[Required]
        //public Guid AdressId { get; set; }
    }

    
}
