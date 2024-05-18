using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;
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

        public async Task<IEnumerable<AddressDTO>> GetAllAddressAsync()
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");

                var response = await httpClient.GetAsync("/api/Address/");
                response.EnsureSuccessStatusCode();
                var addressDTO = await response.Content.ReadFromJsonAsync<List<AddressDTO>>();
                return addressDTO;
            }
            catch (Exception ex)
            {
                return new List<AddressDTO>();
            }
        }

        public Task<bool> CreateAddressAsync(CreateAddressDTO createAddressDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAddressAsync(UpdateAddressDTO updateAddressDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAddressAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
