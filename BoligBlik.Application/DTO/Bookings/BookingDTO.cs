using System.Runtime.InteropServices.JavaScript;
using BoligBlik.Application.Common.Entity;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.Bookings
{
    public class BookingDTO : EntityDTO
    {
        public AddressDTO Address { get; set; }
        public BookingItemDTO Item { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
