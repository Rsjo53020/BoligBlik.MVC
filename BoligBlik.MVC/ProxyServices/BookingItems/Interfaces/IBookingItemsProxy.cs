using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.Models.BookingItems;

namespace BoligBlik.MVC.ProxyServices.BookingItems.Interfaces
{
    public interface IBookingItemsProxy
    {
        Task<IEnumerable<BookingItemDTO>> GetAllBookingItems();
        Task<BookingItemDTO> GetBookingItem(Guid itemId);
    }
}
