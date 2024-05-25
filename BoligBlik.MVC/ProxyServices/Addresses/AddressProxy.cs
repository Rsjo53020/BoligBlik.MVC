using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Net.Http.Json;

namespace BoligBlik.MVC.ProxyServices.Addresses
{
    public class AddressProxy : IAddressProxy
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<AddressProxy> _logger ;

        public AddressProxy(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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


                var address = await response.Content.ReadFromJsonAsync<List<AddressDTO>>();
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

        public async Task<bool> UpdateAddressAsync(UpdateAddressDTO updateAddressDTO)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");

                //var currentItem = await GetAddressAsync(updateAddressDTO.Id);

                //if (!currentItem.RowVersion.SequenceEqual(updateAddressDTO.RowVersion))
                //{
                //    throw new DbUpdateConcurrencyException("Concurrency conflict occurred.");
                //}

                var response = await httpClient.PutAsJsonAsync("/api/Address", updateAddressDTO);
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

        public async Task<bool> DeleteAddressAsync(AddressDTO addressDto)
        {
            try
            {
                //var httpClient = _httpClientFactory.CreateClient("BaseClient");

                //var currentItem = await DeleteAddressAsync(addressDto);

                //if (!currentItem.RowVersion.SequenceEqual(addressDto.RowVersion))
                //{
                //    throw new Exception("Concurrency conflict occurred.");
                //}

                //var response = await httpClient.DeleteFromJsonAsync("/api/Address", addressDto);
                //response.EnsureSuccessStatusCode();
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


