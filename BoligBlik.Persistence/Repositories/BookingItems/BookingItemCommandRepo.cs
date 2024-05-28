using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.BookingItems
{
    public class BookingItemCommandRepo : IBookingItemCommandRepo
    {
        private readonly BoligBlikContext _dbContext;
        private readonly ILogger<BookingItem> _logger;

        public BookingItemCommandRepo(BoligBlikContext dbContext, ILogger<BookingItem> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

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

        public void UpdateBookingItem(BookingItem bookingItem)
        {
            try
            {
                _dbContext.Update(bookingItem).Property(b => b.RowVersion).OriginalValue = bookingItem.RowVersion; ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in UpdateBookingItem");
            }
        }

        public void DeleteBookingItem(Guid id)
        {
            try
            {
                _dbContext.Remove(_dbContext.BookingItems.Where(x => x.Id == id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in DeleteBookingItem");
            }
        }
    }
}
