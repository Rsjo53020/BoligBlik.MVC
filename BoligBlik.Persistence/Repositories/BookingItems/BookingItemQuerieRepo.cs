using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.BookingItems
{
    public class BookingItemQuerieRepo : IBookingItemQuerieRepo
    {
        private readonly BoligBlikContext _db;
        private readonly ILogger<BookingItem> _logger;

        public BookingItemQuerieRepo(BoligBlikContext db, ILogger<BookingItem> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<BookingItem> ReadBookingItemsAsync(string title)
        {
            try
            {
                return await _db.BookingItems.FirstOrDefaultAsync(x => x.Name == title);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ReadBookingItem {ex}");
                return null;
            }
        }

        public async Task<IEnumerable<BookingItem>> ReadAllBookingItemsAsync()
        {
            try
            {
                return await _db.BookingItems.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ReadAllBookingItems {ex}");
                return Enumerable.Empty<BookingItem>();
            }
        }
    }
}
