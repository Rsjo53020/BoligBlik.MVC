using BoligBlik.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.Bookings;

namespace BoligBlik.Application.Interfaces.Bookings
{
    /// <summary>
    /// Interface for BookingQuerieService
    /// </summary>
    public interface IBookingQuerieService
    {
        Task<BookingDTO> ReadBookingAsync(Guid id);
        Task<IEnumerable<BookingDTO>> ReadAllBookingAsync();
    }
}
