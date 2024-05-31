using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.BookingItems;

namespace BoligBlik.Application.Interfaces.BookingItems.Commands
{
    /// <summary>
    /// Interface for BookingItemCommandService
    /// </summary>
    public interface IBookingItemCommandService
    {
        void CreateBookingItem(CreateBookingItemDTO request);
        void UpdateBookingItem(BookingItemDTO request);
        void DeleteBookingItem(Guid id, Byte[] rowVersion);
    }
}
