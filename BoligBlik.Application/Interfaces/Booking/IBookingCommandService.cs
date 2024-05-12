using BoligBlik.Application.DTO.Booking;

namespace BoligBlik.Application.Interfaces.Booking
{
    public interface IBookingCommandService
    {
        void CreateBooking(CreateBookingDTO createBookingDTO);
        void UpdateBooking(UpdateBookingDTO updateBookingDTO);
        void DeleteBooking(DeleteBookingDTO deleteBookingDTO);
    }
}