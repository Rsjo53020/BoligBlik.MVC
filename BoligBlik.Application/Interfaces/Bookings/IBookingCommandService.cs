using BoligBlik.Application.DTO.Bookings;

namespace BoligBlik.Application.Interfaces.Bookings
{
    public interface IBookingCommandService
    {
        void CreateBooking(CreateBookingDTO request);
        void UpdateBooking(BookingDTO updateBookingDTO);
        void DeleteBooking(Guid id);
    }
}