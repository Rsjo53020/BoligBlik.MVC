using System.Net.Http;
using System.Text.Json;
using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.ProxyServices.BookingItems.Interfaces;

namespace BoligBlik.MVC.ProxyServices.BookingItems
{
    public class BookingItemsProxy : IBookingItemsProxy
    {
        //client factory 
        private readonly IHttpClientFactory _clientFactory;
        //logger
        private readonly ILogger<BookingItemsProxy> _logger;

        public BookingItemsProxy(IHttpClientFactory clientFactory, ILogger<BookingItemsProxy> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Creates an item
        /// </summary>
        /// <param name="bookingItemDTO"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
                _logger.LogError("HTTP Request Error:", ex.Message);
            }
        }
        /// <summary>
        /// Reads all booking items
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<BookingItemDTO>> GetAllBookingItems()
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.GetAsync("api/BookingItems");
                response.EnsureSuccessStatusCode();

                var bookingItems = await response.Content.ReadFromJsonAsync<IEnumerable<BookingItemDTO>>();
                return bookingItems ?? new List<BookingItemDTO>();
            }
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return new List<BookingItemDTO>();
            }
        }
        /// <summary>
        /// Read an item 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<BookingItemDTO> GetBookingItem(Guid id)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");
                var response = await httpClient.GetAsync($"api/BookingItems/{id}");
                response.EnsureSuccessStatusCode();

                var bookingItem = await response.Content.ReadFromJsonAsync<BookingItemDTO>();
                return bookingItem;
            }
            catch(Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return new BookingItemDTO();
            }
        }
        /// <summary>
        /// Updates an item
        /// </summary>
        /// <param name="bookingItemDTO"></param>
        /// <returns></returns>
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
                _logger.LogError("HTTP Request Error:", ex.Message);
            }
        }

        /// <summary>
        /// Delete an item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
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
                _logger.LogError("HTTP Request Error:", ex.Message);
            }

        }

    }
}
