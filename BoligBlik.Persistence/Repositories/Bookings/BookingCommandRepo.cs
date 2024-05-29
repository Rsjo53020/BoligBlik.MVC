using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories
{
    public class BookingCommandRepo : IBookingCommandRepo
    {
        private readonly BoligBlikContext _dbContext;
        private readonly ILogger<Booking> _logger;

        public BookingCommandRepo(BoligBlikContext dbContext)
        {
            _dbContext = dbContext;
        }
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




        public void UpdateBooking(Booking booking)
        {
            try
            {
                _dbContext.Update(booking).Property(b => b.RowVersion).OriginalValue = booking.RowVersion;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error in update in Booking: " + ex.Message);
                _logger.LogError("Error in update in Booking: " + ex.Message);
            }
        }

        public void DeleteBooking(Guid id)
        {
            try
            {
                var booking = _dbContext.Bookings.Find(id);
                _dbContext.Bookings.Remove(booking);
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in delete in Booking: " + ex.Message);
            }
        }
    }
}
