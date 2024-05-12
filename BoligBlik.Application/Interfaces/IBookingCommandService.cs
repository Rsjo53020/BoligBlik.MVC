using BoligBlik.Application.DTO.Booking;

namespace BoligBlik.Application.Interfaces
{
    public interface IBookingCommandService
    {
        void CreateBooking(CreateBookingDTO createBookingDTO);
        void UpdateBooking(UpdateBookingDTO updateBookingDTO);
        void DeleteBooking(DeleteBookingDTO deleteBookingDTO);
    }
}