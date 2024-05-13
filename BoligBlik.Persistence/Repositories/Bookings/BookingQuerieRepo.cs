using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BoligBlik.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.Bookings
{
    public class BookingQuerieRepo : IBookingQuerieRepo
    {
        private readonly BoligBlikContext _dbContext;
        private readonly ILogger<Booking> _logger;

        public BookingQuerieRepo(BoligBlikContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Booking>> ReadAllAsync()
        {
            try
            {
                return await _dbContext.Bookings.AsNoTracking().ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ReadAll in Booking: " + ex.Message);
                return Enumerable.Empty<Booking>();
            }
        }

        public async Task<Booking> ReadBooking(Guid id)
        {
            try
            {
                return await _dbContext.Bookings.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ReadBooking in BookingRepository " + ex.Message);
                throw new ApplicationException("Error in ReadBooking in BookingRepository ", ex);
            }
        }
    }
}
