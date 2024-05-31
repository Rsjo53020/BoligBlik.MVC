using BoligBlik.MVC.DTO.Bookings;

namespace BoligBlik.MVC.ProxyServices.Bookings.Interfaces
{
    public interface IBookingProxy
    {
        Task CreateBooking(CreateBookingDTO createBookingDTO);
        Task<BookingDTO> GetBooking(Guid id);
        Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
        Task<bool> UpdateBookingAsync(BookingDTO booking);
        Task DeleteBooking(Guid id, string rowVersion);

    }
}
