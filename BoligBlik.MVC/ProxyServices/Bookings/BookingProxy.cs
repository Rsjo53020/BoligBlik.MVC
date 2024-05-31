using AutoMapper;
using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.ProxyServices.Bookings.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.MVC.ProxyServices.Bookings
{
    public class BookingProxy : IBookingProxy
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<BookingProxy> _logger;

        public BookingProxy(IHttpClientFactory clientFactory, ILogger<BookingProxy> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        /// <summary>
        /// Create a Booking
        /// </summary>
        /// <param name="createBookingDTO"></param>
        /// <returns></returns>
        public async Task CreateBooking(CreateBookingDTO createBookingDTO)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.PostAsJsonAsync("/api/Booking", createBookingDTO);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
            }
        }

        /// <summary>
        /// Read a Booking 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BookingDTO> GetBooking(Guid id)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");
                var response = await httpClient.GetAsync($"api/Booking/{id}");
                response.EnsureSuccessStatusCode();
                var booking = await response.Content.ReadFromJsonAsync<BookingDTO>();
                return booking;
            }
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return new BookingDTO();
            }
        }

        /// <summary>
        /// Update a Booking
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public async Task<bool> UpdateBookingAsync(BookingDTO booking)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");
                var response = await httpClient.PutAsJsonAsync("/api/Booking", booking);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Delete a Booking
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task DeleteBooking(Guid id, string rowVersion)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");
                var response = await httpClient.DeleteAsync($"/api/Booking/{id}/{rowVersion}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
            }
        }

        /// <summary>
        /// Read All Booking
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
        {
            try
            {
                using var httpClient = _clientFactory.CreateClient("BaseClient");

                var response = await httpClient.GetAsync("/api/Booking");

                if (!response.IsSuccessStatusCode)
                {
                    return Enumerable.Empty<BookingDTO>();
                }

                var allBookings = await response.Content.ReadFromJsonAsync<IEnumerable<BookingDTO>>();

                return allBookings ?? new List<BookingDTO>();
            }

            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return new List<BookingDTO>();
            }
        }
    }
}
