using System.Net.Http;
using System.Text;
using System.Text.Json;
using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.ProxyServices.Bookings.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.MVC.ProxyServices.Bookings
{
    public class BookingProxy : IBookingProxy
    {
        private readonly IHttpClientFactory _clientFactory;

        public BookingProxy(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

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
                throw new Exception($"Error occurred while create a booking data: {ex.Message}");
            }
        }

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
            catch (HttpRequestException httpRequestException)
            {
                throw new Exception("HTTP Request Error: " + httpRequestException.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while getting booking data", ex);
            }
        }

        public async Task<bool> UpdateBookingAsync(BookingDTO booking)
        {
            try
            {
                var httpClient = _clientFactory.CreateClient("BaseClient");
                var response = await httpClient.PutAsJsonAsync($"/api/Booking", booking);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating booking data", ex);
            }
        }

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
                throw new Exception("Error occurred while deleting booking data", ex);
            }
        }

    }
}
