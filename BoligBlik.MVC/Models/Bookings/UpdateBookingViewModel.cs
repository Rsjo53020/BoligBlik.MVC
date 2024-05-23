﻿namespace BoligBlik.MVC.Models.Bookings
{
    public class UpdateBookingViewModel
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool Approved { get; set; }
        public Guid ItemId { get; set; }
        public Guid AddressId { get; set; }
    }
}
