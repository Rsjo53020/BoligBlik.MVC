using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.MVC.DTO.BookingItems
{
    public class DeleteBookingItemDTO
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
