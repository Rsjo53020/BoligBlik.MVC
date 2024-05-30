using BoligBlik.Application.DTO.Bookings;

namespace BoligBlik.Application.Interfaces.Bookings
{
    public interface IBookingCommandService
    {
        void CreateBooking(CreateBookingDTO request);
        void UpdateBooking(BookingDTO request);
        void DeleteBooking(Guid id, Byte[] rowVersion);
    }
}