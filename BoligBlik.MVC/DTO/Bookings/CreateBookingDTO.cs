﻿using BoligBlik.MVC.DTO.BookingItems;

namespace BoligBlik.MVC.DTO.Bookings
{
    public class CreateBookingDTO
    {
        public Guid AddressId { get; set; }
        public BookingItemDTO Item { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
