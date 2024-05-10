using BoligBlik.Application.Dto.Booking;

namespace BoligBlik.Application.Interfaces
{
    public interface IBookingCommandService
    {
        void CreateBooking(CreateBookingDto createBookingDto);
        void UpdateBooking(UpdateBookingDto updateBookingDto);
        void DeleteBooking(DeleteBookingDto deleteBookingDto);
    }
}