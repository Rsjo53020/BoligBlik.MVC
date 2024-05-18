using BoligBlik.Application.DTO.Address;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.DTO.Payments;
using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.Bookings
{

    public class CreateBookingDTO : IBaseEntity, IEntity
    {
        public BookingDatesDTO BookingDates { get; set; }
        public AddressDTO Address { get; set; }
        public UserDTO User { get; set; }
        public PaymentDTO Payment { get; set; }
        public BookingItemDTO Item { get; set; }
        public Guid? CreateBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; }
        public Guid? DeletedBy { get; set; }
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
