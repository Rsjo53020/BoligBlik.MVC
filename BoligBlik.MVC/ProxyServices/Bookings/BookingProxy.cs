﻿using System.Text;
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
                var content = new StringContent(JsonSerializer.Serialize(createBookingDTO), Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("api/Bookings/Create", content);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while creating booking", ex);
            }
        }
    }
}