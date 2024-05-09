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
        private readonly IBookingDomainService _bookingDomainService;
        public BookingDates BookingDates { get; set; }
        public Address Address { get; set; }


        //hvorfor??
        //[Required]
        //public Boolean Approved { get; set; }

        internal Booking() : base(Guid.NewGuid()) { }

        internal Booking(Guid id, BookingDates bookingDates, /*Item item, Payment payment, Address address,*/ IBookingDomainService bookingDomainService) : base(id)
        {
            this.BookingDates = bookingDates;
            //this.Item = item;
            //this.Payment = payment;
            //this.Address = address;
            _bookingDomainService = bookingDomainService;

            ValidateBooking();
        }

        private void ValidateBooking()
        {
            ValidateTimeInput(nameof(BookingDates.startTime), BookingDates.startTime);
            ValidateTimeInput(nameof(BookingDates.endTime), BookingDates.endTime);

            if (_bookingDomainService.IsBookingOverlapping(this))
            {
                throw new BookingIsOverlappingException("Booking overlaps with existing booking");
            }

            


            //public static Booking Create(BookingDates bookingDates, Item item, Payment payment, Address address,
            //   IBookingDomainService bookingDomainService)
            //{
            //    //creationDate = DateOnly.FromDateTime(DateTime.Now);
            //    if (bookingDates == null) throw new ArgumentNullException(nameof(bookingDates));

            //    //if (endTime == null) throw new ArgumentNullException(nameof(endTime));

            //    if (item == null) throw new ArgumentNullException(nameof(item));

            //    if (address == null) throw new ArgumentNullException(nameof(address));


            //    var domainService = services.GetService<_>();

            //    if (domainService == null) throw new ArgumentNullException(nameof(domainService));

            //    var booking = new Booking(Guid.NewGuid(),bookingDates, item, payment, address, bookingDomainService);

            //    if (_bookingDomainService.IsBookingOverlapping(domainService.OtherBookings(booking)))
            //    {
            //        throw new BookingIsOverlappingException("Booking overlaps with existing booking");
            //    }

            //    return booking;
        }
      

        public void ValidateTimeInput(string parameter, DateTime dateTime)
        {
            if (dateTime == null || dateTime == default)
            {
                throw new TimeNotSetException($"{parameter} is not set");
            }


            if (dateTime < _bookingDomainService.NowTime())
            {
                throw new TimeInPastException($"{parameter} is not set in the future");
            }


        }

    }
}
