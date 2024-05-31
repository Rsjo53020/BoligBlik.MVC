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
            var step1 = _dbContext.Bookings.Any(other =>
                (booking.BookingDates.startTime <= other.BookingDates.startTime &&
                 booking.BookingDates.startTime >= other.BookingDates.endTime));

            var step2 = _dbContext.Bookings.Any(other =>
                (booking.BookingDates.endTime >= other.BookingDates.endTime &&
                 booking.BookingDates.endTime <= other.BookingDates.startTime));

            var step3 = _dbContext.Bookings.Any(other =>
                (booking.BookingDates.endTime <= other.BookingDates.endTime &&
                 booking.BookingDates.startTime >= other.BookingDates.startTime));

            //var response = _dbContext.Bookings.Any(other =>
            //    // Check if the start date of the given booking is before or equal to the end date of another booking
            //    // and if the end date of the given booking is after or equal to the start date of another booking
            //    (booking.BookingDates.startTime <= other.BookingDates.endTime && 
            //     booking.BookingDates.endTime >= other.BookingDates.startTime) ||

            //    // Check if the start date of the given booking is after or equal to the start date of another booking
            //    // and if the start date of the given booking is before or equal to the end date of another booking
            //    (booking.BookingDates.startTime >= other.BookingDates.startTime && 
            //     booking.BookingDates.startTime <= other.BookingDates.endTime) ||

            //    // Check if the start date of the given booking is before or equal to the start date of another booking
            //    // and if the end date of the given booking is after or equal to the end date of another booking
            //    (booking.BookingDates.startTime <= other.BookingDates.startTime && 
            //     booking.BookingDates.endTime >= other.BookingDates.endTime)
            //);

            return true;
        }

        public DateTime NowTime()
        {
            return DateTime.Now;
        }
    }

}
