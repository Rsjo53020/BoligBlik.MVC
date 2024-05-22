using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace BoligBlik.MVC.ProxyServices.Addresses
{
    public class AddressProxy : IAddressProxy
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AddressProxy(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<bool> CreateAddressAsync(CreateAddressDTO createAddressDTO)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");

                var response = await httpClient.PutAsJsonAsync("/api/Address", createAddressDTO);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while create a address data", ex);
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

                var currentItem = await GetAddressAsync(updateAddressDTO.Id);

                if (!currentItem.RowVersion.SequenceEqual(updateAddressDTO.RowVersion))
                {
                    throw new DbUpdateConcurrencyException("Concurrency conflict occurred.");
                }

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

        //public async Task<bool> DeleteAddressAsync(DeleteAddressDTO deleteAddressDto)
        //{
        //    try
        //    {
        //        var httpClient = _httpClientFactory.CreateClient("BaseClient");

        //        var currentItem = await DeleteAddressAsync(deleteAddressDto);

        //        if (!currentItem.RowVersion.SequenceEqual(deleteAddressDto.RowVersion))
        //        {
        //            throw new Exception("Concurrency conflict occurred.");
        //        }

        //        var response = await httpClient.DeleteFromJsonAsync("/api/Address", deleteAddressDto);
        //        response.EnsureSuccessStatusCode();
        //        return true;
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        throw new Exception("Error occurred while updating a address data", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error occurred while updating a address data", ex);
        //    }
    }
}


