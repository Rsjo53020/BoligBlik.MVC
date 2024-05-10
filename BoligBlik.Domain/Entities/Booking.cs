using BoligBlik.Domain.Value;
using System.ComponentModel.DataAnnotations;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Common.Shared;
using BoligBlik.Domain.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace BoligBlik.Domain.Entities
{
    public class Booking : Entity
    {
        
        //måske ud i value obj
        public DateOnly CreationDate { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        //istedet for overstående??
        public BookingDates BookingDates { get; set; }

        //hvorfor??
        [Required]
        public Boolean Approved { get; set; }
        [Required]
        public Item Item { get; set; }
        public Payment Payment { get; set; }
        public Address Address { get; set; }


        internal Booking() : base(Guid.NewGuid()) { }

        internal Booking(Guid id, BookingDates bookingDates, /*DateOnly creationDate, DateTime startTime, DateTime endTime Boolean approved*/ 
            Item item, Payment payment, Address address) : base(id)
        {
            this.BookingDates = bookingDates;
            //this.CreationDate = creationDate;
            //this.StartTime = startTime;
            //this.EndTime = endTime;
            //this.Approved = approved;
            this.Item = item;
            this.Payment = payment;
            this.Address = address;
           
            //ValidateBooking();
        }

        private bool IsBookingOverlapping(IEnumerable<Booking> otherBookings)
        {
            return otherBookings.Any(other =>
                (BookingDates.endTime <= other.EndTime && BookingDates.endTime >= other.StartTime) ||
                (BookingDates.startTime >= other.StartTime && BookingDates.startTime <= other.EndTime) ||
                (BookingDates.startTime <= other.StartTime && BookingDates.endTime >= other.EndTime));
        }

        
        public static Booking Create(BookingDates bookingDates, /*DateOnly creationDate, DateTime startTime, DateTime endTime*/ Item item, Payment payment, Address address,
            IServiceProvider services)
        {
            //creationDate = DateOnly.FromDateTime(DateTime.Now);
            if (bookingDates == null) throw new ArgumentNullException(nameof(bookingDates));

            //if (endTime == null) throw new ArgumentNullException(nameof(endTime));

            if (item == null) throw new ArgumentNullException(nameof(item));

            if (address == null) throw new ArgumentNullException(nameof(address));

            if (services == null) throw new ArgumentNullException(nameof(services));

            var domainService = services.GetService<IBookingDomainService>();

            if (domainService == null) throw new ArgumentNullException(nameof(domainService));

            var booking = new Booking(Guid.NewGuid(),bookingDates, /*creationDate, startTime, endTime,*/ item, payment, address);

            if (booking.IsBookingOverlapping(domainService.OtherBookings(booking)))
            {
                throw new BookingIsOverlappingException("Booking overlaps with existing booking");
            }

            return booking;
        }

        public void Update(BookingDates bookingDates, /*DateOnly creationDate, DateTime startTime, DateTime endTime,*/ IServiceProvider services)
        {
            if (bookingDates == null) throw new ArgumentNullException(nameof(bookingDates));

            if (services == null) throw new ArgumentNullException(nameof(services));

            var domainService = services.GetService<IBookingDomainService>();

            if (domainService == null) throw new ArgumentNullException(nameof(domainService));

            this.BookingDates = bookingDates;

            if (IsBookingOverlapping(domainService.OtherBookings(this)))
                throw new BookingIsOverlappingException("Booking overlaps with existing booking");
        }

    }
}
