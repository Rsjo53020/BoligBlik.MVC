using System.Net.Http;
using System.Text;
using System.Text.Json;
using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.ProxyServices.Bookings.Interfaces;

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

                var response = await httpClient.PostAsJsonAsync("/api/Booking/Create", createBookingDTO);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while create a address data: {ex.Message}");
            }
        }

    }
}
