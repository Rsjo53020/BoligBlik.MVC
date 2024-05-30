using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using BoligBlik.Domain.Value;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Common.Shared;
using BoligBlik.Domain.Exceptions;
using BoligBlik.Entities;
using Microsoft.Extensions.DependencyInjection;


namespace BoligBlik.Domain.Entities
{
    public class Booking : Entity
    {
        public Guid AddressId { get; set; }
        public BookingDates BookingDates { get; set; }
        public BookingItem Item { get; set; }

        public static Booking Create(DateTime startTime, DateTime endTime, BookingItem item, Guid addressId, IBookingDomainService _bookingDomainService)
        {
            var booking = new Booking(startTime, endTime, item, addressId);
            var isOverlapping = booking.IsOverlapping(_bookingDomainService, booking);

            if (!isOverlapping)
            {
                return booking;
            }

            if (isOverlapping)
            {
                throw new Exception("Booking is overlapping");
            }

            else
            {
                throw new Exception("Fail during create booking");
            }
        }

        private Booking() : base()
        {
            
        }

        private Booking(DateTime startTime, DateTime endTime, BookingItem item, Guid addressId) : base()
        {
            BookingDates = new BookingDates(startTime, endTime);
            this.Item = item;
            this.AddressId = addressId;

            ValidateBooking();
        }

        private void ValidateBooking()
        {
            ValidateTimeInput(nameof(BookingDates.startTime), BookingDates.startTime);
            ValidateTimeInput(nameof(BookingDates.endTime), BookingDates.endTime);
        }

        private void ValidateTimeInput(string parameter, DateTime dateTime)
        {
            if (dateTime == null || dateTime == default)
            {
                throw new TimeNotSetException($"{parameter} is not set");
            }
            if (dateTime < DateTime.Now)
            {
                throw new TimeInPastException($"{parameter} is not set in the future");
            }
        }

        private bool IsOverlapping(IBookingDomainService _bookingDomainService, Booking booking)
        {
            return _bookingDomainService.IsBookingOverlapping(booking);
        }

        
    }
}
