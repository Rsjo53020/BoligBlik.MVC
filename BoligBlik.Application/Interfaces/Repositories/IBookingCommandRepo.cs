using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.Repositories
{
    public interface IBookingCommandRepo
    {
        void CreateBooking(Booking booking);
        void UpdateBooking(Booking booking);
        void DeleteBooking(Guid id, Byte[] rowVersion);
    }
}
