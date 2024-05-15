using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.MVC.DTO.BookingItems
{
    public class UpdateBookingItemDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public string Repairs { get; set; }
        public string ImageFilePath { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
