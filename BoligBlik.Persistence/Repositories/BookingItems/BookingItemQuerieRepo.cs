using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.BookingItems
{
    public class BookingItemQuerieRepo : IBookingItemQuerieRepo
    {
        //context
        private readonly BoligBlikContext _db;
        //logger
        private readonly ILogger<BookingItem> _logger;

        public BookingItemQuerieRepo(BoligBlikContext db, ILogger<BookingItem> logger)
        {
            _db = db;
            _logger = logger;
        }

        /// <summary>
        /// reads a booking item from an id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BookingItem> ReadBookingItemsAsync(Guid itemId)
        {
            try
            {
                return await _db.BookingItems.FirstOrDefaultAsync(x => x.Id == itemId);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ReadBookingItem", ex.Message);
                throw new Exception("something went wrong when reading all boardMembers");
            }
        }

        /// <summary>
        /// reads all booking items
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<BookingItem>> ReadAllBookingItemsAsync()
        {
            try
            {
                return await _db.BookingItems.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ReadBookingItem", ex.Message);
                throw new Exception("something went wrong when reading all boardMembers");
            }
        }
    }
}
