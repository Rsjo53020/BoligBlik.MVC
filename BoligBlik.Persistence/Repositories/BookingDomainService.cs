using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Entities;
using BoligBlik.Domain.Value;
using BoligBlik.Persistence.Contexts;

namespace BoligBlik.Persistence.Services
{
    public class BookingDomainService : IBookingDomainService
    {
        private readonly BookingDbContext _dbContext;

        public BookingDomainService(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public bool IsBookingOverlapping(Booking booking)
        {
            return _dbContext.Bookings.Any(other =>
                //This checks if the end date of the given booking is between the start and end date of another booking
                (booking.BookingDates.endTime <= other.BookingDates.endTime && booking.BookingDates.endTime >= other.BookingDates.startTime) ||
                //This checks if the start date of the given booking is between the start and end date of another booking
                (booking.BookingDates.startTime >= other.BookingDates.startTime && booking.BookingDates.startTime <= other.BookingDates.endTime) ||
                //This checks if the given booking contains another booking,
                //i.e. its start date is before or equal to the start date of the other booking and its end date is after or equal to the end date of the other booking
                (booking.BookingDates.startTime <= other.BookingDates.startTime && booking.BookingDates.endTime >= other.BookingDates.endTime));
        }

        public DateTime NowTime()
        {
            return DateTime.Now;
        }
    }

}
