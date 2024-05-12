using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.DTO.Booking
{
    public class DeleteBookingDTO
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; } = [];
    }
}
