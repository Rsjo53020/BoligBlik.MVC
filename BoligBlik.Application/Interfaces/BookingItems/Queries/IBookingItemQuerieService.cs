using BoligBlik.Application.DTO.BoardMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.BookingItems;

namespace BoligBlik.Application.Interfaces.BookingItems.Queries
{
    /// <summary>
    /// Interface for BookingItemQuerieService
    /// </summary>
    public interface IBookingItemQuerieService
    {
        Task<BookingItemDTO> ReadBookingItemAsync(Guid itemId);
        Task<IEnumerable<BookingItemDTO>> ReadAllBookingItemsAsync();
    }
}
