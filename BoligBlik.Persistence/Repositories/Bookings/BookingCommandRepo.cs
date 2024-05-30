using BoligBlik.Application.Interfaces.Repositories.Bookings.Command;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories
{
    public class BookingCommandRepo : IBookingCommandRepo
    {
        //Dependencies
        private readonly BoligBlikContext _dbContext;
        private readonly ILogger<BookingCommandRepo> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="logger"></param>
        public BookingCommandRepo(BoligBlikContext dbContext, 
            ILogger<BookingCommandRepo> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Create booking and Attach BookingItem using EF.
        /// </summary>
        /// <param name="booking"></param>
        public void CreateBooking(Booking booking)
        {
            try
            {
                _dbContext.Attach(booking.Item);
                _dbContext.Add(booking);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Error in create in Booking: " + ex.Message);
            }
        }

        /// <summary>
        /// Update Booking and RowVersion Check
        /// </summary>
        /// <param name="booking"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateBooking(Booking booking)
        {
            try
            {
                //Concurrency Check by Original and Paramater RowVersion 
                _dbContext.Update(booking).Property(b => b.RowVersion).OriginalValue = booking.RowVersion;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error in update in Booking: " + ex.Message);
                _logger.LogError("Error in update in Booking: " + ex.Message);
            }
        }

        /// <summary>
        /// Delete Booking and RowVersion Check
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        public void DeleteBooking(Guid id, Byte[] rowVersion)
        {
            try
            {
                var booking = _dbContext.Bookings.Find(id);
                _dbContext.Bookings.Remove(booking).Property(b => b.RowVersion).OriginalValue = rowVersion;
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in delete in Booking: " + ex.Message);
            }
        }
    }
}
