using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Json;

namespace BoligBlik.MVC.ProxyServices.Addresses
{
    public class AddressProxy : IAddressProxy
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AddressProxy> _logger;

        public AddressProxy(IHttpClientFactory httpClientFactory, ILogger<AddressProxy> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }


        public async Task<bool> CreateAddressAsync(CreateAddressDTO address)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");

                var response = await httpClient.PostAsJsonAsync("/api/Address", address);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception($"Error occurred while create a address data: {ex.Message}");
            }
        }

        public async Task<IEnumerable<AddressDTO>> GetAllAddressAsync()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");
                var response = await httpClient.GetAsync("api/address");
                response.EnsureSuccessStatusCode();
                var address = await response.Content.ReadFromJsonAsync<IEnumerable<AddressDTO>>();
                return address ?? new List<AddressDTO>();
            }
            catch (HttpRequestException httpRequestException)
            {
                new Exception("HTTP Request Error: " + httpRequestException.Message, httpRequestException);
                return new List<AddressDTO>();
            }
            catch (Exception ex)
            {
                new Exception("Error occurred while getting all addresses data", ex);
                return new List<AddressDTO>();

            }
        }

        public async Task<AddressDTO> GetAddressAsync(Guid id)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");

                var response = await httpClient.GetAsync($"api/Address/{id}");
                response.EnsureSuccessStatusCode();
                var address = await response.Content.ReadFromJsonAsync<AddressDTO>();
                return address;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error occurred while getting a address data", ex);
            }
        }


        public async Task<bool> UpdateAddressAsync(AddressDTO addressDTO)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");


                var response = await httpClient.PutAsJsonAsync("/api/Address", addressDTO);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Error occurred while updating a address data", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating a address data", ex);
            }
        }
    }
}


