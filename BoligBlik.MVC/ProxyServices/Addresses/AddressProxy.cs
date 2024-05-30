using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;

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

        /// <summary>
        /// Create an Address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
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
                _logger.LogError("HTTP Request Error:", ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Read All Address
        /// </summary>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return new List<AddressDTO>();
            }
        }

        /// <summary>
        /// Read one Address
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return new AddressDTO();
            }
        }

        /// <summary>
        /// Update an Address
        /// </summary>
        /// <param name="addressDTO"></param>
        /// <returns></returns>
        public async Task<bool> UpdateAddressAsync(AddressDTO addressDTO)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient("BaseClient");


                var response = await httpClient.PutAsJsonAsync("/api/Address", addressDTO);
                response.EnsureSuccessStatusCode();
                return true;
            }

            catch (Exception ex)
            {
                _logger.LogError("HTTP Request Error:", ex.Message);
                return false;
            }
        }
    }
}


