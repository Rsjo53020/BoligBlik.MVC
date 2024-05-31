using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using BoligBlik.Domain.Value;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Common.Shared;
using BoligBlik.Domain.Exceptions;
using BoligBlik.Entities;


namespace BoligBlik.Domain.Entities
{
    public class Booking : Entity
    {
        public Guid AddressId { get; set; }
        public BookingDates BookingDates { get; set; }
        public BookingItem Item { get; set; }

        /// <summary>
        /// Factory for creating a booking, Domain driven design pattern.
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="item"></param>
        /// <param name="addressId"></param>
        /// <param name="_bookingDomainService"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static Booking Create(DateTime startTime,
            DateTime endTime,
            BookingItem item,
            Guid addressId,
            IBookingDomainService _bookingDomainService)
        {
            var booking = new Booking(startTime, endTime, item, addressId);
            var isOverlapping = booking.IsOverlapping(_bookingDomainService, booking);

            if (!isOverlapping)
            {
                return booking;
            }
            if (isOverlapping)
            {
                throw new Exception("Booking Is Overlapping with another Booking.");
            }
            else
            {
                throw new Exception("Operation failed during create booking");
            }
        }

        /// <summary>
        /// Private Constructor for Entity Framework. 
        /// </summary>
        private Booking() : base() { }

        /// <summary>
        /// Private Constructor
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="item"></param>
        /// <param name="addressId"></param>
        private Booking(DateTime startTime, DateTime endTime, BookingItem item, Guid addressId) : base()
        {
            BookingDates = new BookingDates(startTime, endTime);
            this.Item = item;
            this.AddressId = addressId;

            ValidateBooking();
        }

        /// <summary>
        ///  ValidateBooking Start and EndTime.
        /// </summary>
        private void ValidateBooking()
        {
            ValidateTimeInput(nameof(BookingDates.startTime), BookingDates.startTime);
            ValidateTimeInput(nameof(BookingDates.endTime), BookingDates.endTime);
        }

        /// <summary>
        /// Validate Booking Start and EndTime Indput.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="dateTime"></param>
        /// <exception cref="TimeNotSetException"></exception>
        /// <exception cref="TimeInPastException"></exception>
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
