using BoligBlik.Application.DTO.Bookings;

namespace BoligBlik.Application.Interfaces.Bookings
{
    /// <summary>
    /// Interface for BookingCommandService
    /// </summary>
    public interface IBookingCommandService
    {
        void CreateBooking(CreateBookingDTO request);
        void UpdateBooking(BookingDTO request);
        void DeleteBooking(Guid id, Byte[] rowVersion);
    }
}