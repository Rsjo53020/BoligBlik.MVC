using System.Text.Json;
using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.ProxyServices.BookingItems.Interfaces;

namespace BoligBlik.MVC.ProxyServices.BookingItems
{
    public class BookingItemsProxy : IBookingItemsProxy
    {
        private readonly IHttpClientFactory _clientFactory;

        public BookingItemsProxy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<BookingItemDTO>> GetAllBookingItems()
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.GetAsync("api/BookingItems/All");
                response.EnsureSuccessStatusCode();

                var bookingItems = await response.Content.ReadFromJsonAsync<IEnumerable<BookingItemDTO>>();
                return bookingItems;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while fetching booking items data", ex);
            }
        }

        public async Task<BookingItemDTO> GetBookingItem(Guid itemId)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");
                var response = await httpClient.GetAsync($"api/BookingItems/{itemId}");
                response.EnsureSuccessStatusCode();

                var bookingItem = await response.Content.ReadFromJsonAsync<BookingItemDTO>();
                return bookingItem;
            }
            catch
            {
                throw new Exception("Error occurred while fetching booking item data");
            }
        }

    }
}
