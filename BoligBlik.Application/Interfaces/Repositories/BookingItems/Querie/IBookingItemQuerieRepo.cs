using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.Repositories.BookingItems.Querie
{
    public interface IBookingItemQuerieRepo
    {
        Task<BookingItem> ReadBookingItemsAsync(Guid itemId);
        Task<IEnumerable<BookingItem>> ReadAllBookingItemsAsync();
    }
}
