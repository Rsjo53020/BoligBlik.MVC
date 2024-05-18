using BoligBlik.Application.DTO.Address;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.DTO.Payments;
using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.Bookings
{
    public class BookingDTO : IEntity
    {
        public BookingDatesDTO BookingDates{ get; set; }
        public AddressDTO Address { get; set; }
        public UserDTO User { get; set; }
        public PaymentDTO Payment { get; set; }
        public BookingItemDTO Item { get; set; }
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }

    
}
