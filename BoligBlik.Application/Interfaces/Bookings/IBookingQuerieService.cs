using BoligBlik.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.Bookings;

namespace BoligBlik.Application.Interfaces.Bookings
{
    public interface IBookingQuerieService
    {
        public Task<BookingDTO> ReadBooking(BookingDTO bookingDto);
        public Task<IEnumerable<BookingDTO>> ReadAllBooking();

    }
}
