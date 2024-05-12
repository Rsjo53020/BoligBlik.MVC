using BoligBlik.Domain.Value;
using System.ComponentModel.DataAnnotations;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Common.Shared;
using BoligBlik.Domain.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace BoligBlik.Domain.Entities
{
    public class Booking
    {
        private readonly IBookingDomainService _bookingDomainService;

        [Key]
        public Guid Id { get; }
        public BookingDates BookingDates { get; set; }
        public bool Approved { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; private set; }


        //public Address Address { get; set; }
        //public User user { get; set; }
        //public Payment payment { get; set; }
        ////public Item item { get; set; }


        internal Booking() { }

        public Booking(Guid id, BookingDates bookingDates, /*Item item, Payment payment, Address address,*/ bool approved, IBookingDomainService bookingDomainService, byte[] RowVersion) /*: base(id)*/
        {
            this.Id = id;
            this.BookingDates = bookingDates;
            this.Approved = approved;

            //this.Item = item;
            //this.Payment = payment;
            //this.Address = address;
            //this.User = user
            _bookingDomainService = bookingDomainService;
            this.RowVersion = RowVersion;

            ValidateBooking();
        }


        //public static Booking Create(BookingDates bookingDates, bool approved, IBookingDomainService bookingDomainService)
        //{
        //    if (bookingDates == null) throw new ArgumentNullException(nameof(bookingDates));


        //    if (bookingDates == null) throw new ArgumentNullException(nameof(bookingDates));

        //    var booking = new Booking(bookingDates, approved, bookingDomainService);
        //    if (bookingDomainService.IsBookingOverlapping(booking))
        //        throw new BookingIsOverlappingException("Booking overlaps with existing booking");

        //    return booking;
        //}

        private void ValidateBooking()
        {
            ValidateTimeInput(nameof(BookingDates.startTime), BookingDates.startTime);
            ValidateTimeInput(nameof(BookingDates.endTime), BookingDates.endTime);

            if (_bookingDomainService.IsBookingOverlapping(this))
            {
                throw new BookingIsOverlappingException("Booking overlaps with existing booking");
            }


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
