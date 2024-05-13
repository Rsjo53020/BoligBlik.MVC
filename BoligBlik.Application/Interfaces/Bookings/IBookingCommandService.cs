using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Application.DTO.Item;
using BoligBlik.Application.DTO.User;

namespace BoligBlik.Application.Interfaces.Bookings
{
    public interface IBookingCommandService
    {
        void CreateBooking(CreateBookingDTO createBookingDTO/*, UserDTO userDTO, ItemDTO itemDTO*/);
        void UpdateBooking(UpdateBookingDTO updateBookingDTO);
        void DeleteBooking(DeleteBookingDTO deleteBookingDTO);
    }
}