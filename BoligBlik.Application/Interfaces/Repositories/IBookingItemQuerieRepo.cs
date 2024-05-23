using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Interfaces.Repositories
{
    public interface IBookingItemQuerieRepo
    {
        public Task<BookingItem> ReadBookingItemsAsync(string name);
        public Task<BookingItem> ReadBookingItemsAsync(Guid itemId);
        public Task<IEnumerable<BookingItem>> ReadAllBookingItemsAsync();
    }
}
