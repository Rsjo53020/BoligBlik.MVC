using System.Diagnostics;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Value;
using BoligBlik.Persistence.Contexts;

namespace BoligBlik.Persistence.Repositories.Bookings
{
    public class BookingDomainService : IBookingDomainService
    {
        private readonly BoligBlikContext _dbContext;

        public BookingDomainService(BoligBlikContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool IsBookingOverlapping(Booking booking)
        {
            return _dbContext.Bookings
                .Any(other =>
                    (booking.BookingDates.startTime <= other.BookingDates.startTime && booking.BookingDates.endTime >= other.BookingDates.startTime) ||
                    (booking.BookingDates.startTime >= other.BookingDates.startTime && booking.BookingDates.startTime <= other.BookingDates.endTime) ||
                    (booking.BookingDates.startTime <= other.BookingDates.startTime && booking.BookingDates.endTime >= other.BookingDates.endTime)
                );
        }

        public DateTime NowTime()
        {
            return DateTime.Now;
        }
    }

}
