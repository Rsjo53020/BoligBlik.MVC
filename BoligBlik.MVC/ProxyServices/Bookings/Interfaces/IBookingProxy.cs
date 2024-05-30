using BoligBlik.MVC.DTO.Bookings;

namespace BoligBlik.MVC.ProxyServices.Bookings.Interfaces
{
    public interface IBookingProxy
    {
        Task CreateBooking(CreateBookingDTO createBookingDTO);
        Task<BookingDTO> GetBooking(Guid id);
        Task<bool> UpdateBookingAsync(BookingDTO booking);
        Task DeleteBooking(Guid id, string rowVersion);
        Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
    }
}
