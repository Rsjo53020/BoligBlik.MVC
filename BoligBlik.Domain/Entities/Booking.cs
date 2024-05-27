using System.ComponentModel.Design;
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
        public BookingDates BookingDates { get; set; }
        public Address Address { get; set; }
        public BookingItem Item { get; set; }


        internal Booking() : base()
        {
            
        }

        public Booking(DateTime startTime, DateTime endTime, BookingItem item, Address address) : base()
        {
            BookingDates = new BookingDates(startTime, endTime);
            this.Item = item;
            this.Address = address;

            ValidateBooking();
        }

        private void ValidateBooking()
        {
            ValidateTimeInput(nameof(BookingDates.startTime), BookingDates.startTime);
            ValidateTimeInput(nameof(BookingDates.endTime), BookingDates.endTime);
        }

        public void ValidateTimeInput(string parameter, DateTime dateTime)
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
    }
}
