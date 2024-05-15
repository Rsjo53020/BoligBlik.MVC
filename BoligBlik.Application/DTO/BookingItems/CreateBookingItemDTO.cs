using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.DTO.BookingItems
{
    public class CreateBookingItemDTO
    {
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public string Repairs { get; set; }
        public string ImageFilePath { get; set; }
    }
}
