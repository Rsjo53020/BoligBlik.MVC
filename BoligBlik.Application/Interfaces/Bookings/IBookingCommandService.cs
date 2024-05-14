using BoligBlik.Application.DTO.Bookings;

namespace BoligBlik.Application.Interfaces.Bookings
{
    public interface IBookingCommandService
    {
        void CreateBooking(CreateBookingDTO createBookingDTO/*, UserDTO userDTO, ItemDTO itemDTO*/);
        void UpdateBooking(UpdateBookingDTO updateBookingDTO);
        void DeleteBooking(DeleteBookingDTO deleteBookingDTO);
    }
}