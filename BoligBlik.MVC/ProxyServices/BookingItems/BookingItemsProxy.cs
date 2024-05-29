using System.Net.Http;
using System.Text.Json;
using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.ProxyServices.BookingItems.Interfaces;

namespace BoligBlik.MVC.ProxyServices.BookingItems
{
    public class BookingItemsProxy : IBookingItemsProxy
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<BookingItemsProxy> _logger;

        public BookingItemsProxy(IHttpClientFactory clientFactory, ILogger<BookingItemsProxy> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }
        public async Task CreateBookingItem(CreateBookingItemDTO bookingItemDTO)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.PostAsJsonAsync("api/BookingItems", bookingItemDTO);
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException ex)
            {
                _logger.LogError("something went wrong when creating a bookiing item", ex.Message);
                throw new Exception("Error occurred while fetching booking items data", ex);
            }
        }

        public async Task<IEnumerable<BookingItemDTO>> GetAllBookingItems()
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.GetAsync("api/BookingItems");
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

        public async Task UpdateBookingItem(BookingItemDTO bookingItemDTO)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.PutAsJsonAsync("/api/BookingItems", bookingItemDTO);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError("something went wrong when updating bookingitem", ex.Message);
            }
        }

        public async Task DeleteBookingItem(Guid id, string rowVersion)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.DeleteAsync($"/api/BookingItems/{id}/{rowVersion}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError("something went wrong when deleting a booking item", ex.Message);
            }

        }

    }
}
