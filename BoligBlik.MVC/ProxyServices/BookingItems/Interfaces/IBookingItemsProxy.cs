using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.Models.BookingItems;

namespace BoligBlik.MVC.ProxyServices.BookingItems.Interfaces
{
    public interface IBookingItemsProxy
    {
        Task CreateBookingItem(CreateBookingItemDTO bookingItemDTO);
        Task<IEnumerable<BookingItemDTO>> GetAllBookingItems();
        Task<BookingItemDTO> GetBookingItem(Guid itemId);
        Task UpdateBookingItem(BookingItemDTO bookingItemDTO);
        Task DeleteBookingItem(Guid id, string rowVersion);
    }
}
