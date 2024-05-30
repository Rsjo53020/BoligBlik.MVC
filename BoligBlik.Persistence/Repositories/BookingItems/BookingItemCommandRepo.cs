using BoligBlik.Application.Interfaces.Repositories.BookingItems.Command;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.BookingItems
{
    public class BookingItemCommandRepo : IBookingItemCommandRepo
    {
        //context
        private readonly BoligBlikContext _dbContext;
        //logger
        private readonly ILogger<BookingItem> _logger;

        public BookingItemCommandRepo(BoligBlikContext dbContext, ILogger<BookingItem> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        /// <summary>
        /// Creates a booking item
        /// </summary>
        /// <param name="bookingItem"></param>
        public void CreateBookingItem(BookingItem bookingItem)
        {
            try
            {
                _dbContext.AddAsync(bookingItem);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CreateBookingItem");
            }
        }
        /// <summary>
        /// updates a booking item
        /// </summary>
        /// <param name="bookingItem"></param>
        public void UpdateBookingItem(BookingItem bookingItem)
        {
            try
            {
                _dbContext.Update(bookingItem)
                    .Property(b => b.RowVersion).OriginalValue = bookingItem.RowVersion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateBookingItem");
            }
        }
        /// <summary>
        /// deletes a booking item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        public void DeleteBookingItem(Guid id, Byte[] rowVersion)
        {
            try
            {
                _dbContext.Remove(_dbContext.BookingItems.Where(x => x.Id == id).FirstOrDefault())
                    .Property(b => b.RowVersion).OriginalValue = rowVersion;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteBookingItem");
            }
        }
    }
}
