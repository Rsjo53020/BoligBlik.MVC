﻿using BoligBlik.Domain.Value;
using System.ComponentModel.DataAnnotations;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Common.Shared;
using BoligBlik.Domain.Exceptions;
using BoligBlik.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace BoligBlik.Domain.Entities
{
    public class Booking : Entity
    {
        private readonly IBookingDomainService _bookingDomainService;

        public BookingDates BookingDates { get; set; }
        public Address Address { get; set; }
        public Payment Payment { get; set; }
        public BookingItem Item { get; set; }



        internal Booking() : base() { }

        public Booking(BookingDates bookingDates, BookingItem item, Payment payment, Address address, IBookingDomainService bookingDomainService, byte[] RowVersion) : base()
        {
            this.BookingDates = bookingDates;

            this.Item = item;
            this.Payment = payment;
            this.Address = address;
            _bookingDomainService = bookingDomainService;
            this.RowVersion = RowVersion;

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
