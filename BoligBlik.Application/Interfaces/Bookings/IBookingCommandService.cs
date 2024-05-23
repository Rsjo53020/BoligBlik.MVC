using BoligBlik.Application.DTO.Bookings;

namespace BoligBlik.Application.Interfaces.Bookings
{
    public interface IBookingCommandService
    {
        void CreateBooking(CreateBookingDTO createBookingDTO/*, UserDTO userDTO, ItemDTO itemDTO*/);
        void UpdateBooking(BookingDTO updateBookingDTO);
        void DeleteBooking(BookingDTO deleteBookingDTO);
    }
}