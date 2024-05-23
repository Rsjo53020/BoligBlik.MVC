using BoligBlik.MVC.DTO.Bookings;

namespace BoligBlik.MVC.ProxyServices.Bookings.Interfaces
{
    public interface IBookingProxy
    {
        Task CreateBooking(CreateBookingDTO createBookingDTO);
    }
}
