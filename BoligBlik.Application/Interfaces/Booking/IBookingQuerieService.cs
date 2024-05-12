using BoligBlik.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.Booking;

namespace BoligBlik.Application.Interfaces.Booking
{
    public interface IBookingQuerieService
    {
        public BookingDTO ReadBooking(BookingDTO bookingDto);
        public IEnumerable<BookingDTO> ReadAllBooking();

    }
}
