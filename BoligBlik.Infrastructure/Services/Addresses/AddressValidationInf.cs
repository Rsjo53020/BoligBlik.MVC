using System.Drawing;
using System.IO;
using System.Net.Http.Json;
using BoligBlik.Application.Interfaces.Infrastructure;
using BoligBlik.Entities;
using Newtonsoft.Json;


namespace BoligBlik.Infrastructure.Services.Addresses
{
    public class AddressValidationInf : IAddressValidationInf
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AddressValidationInf(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

      
        public async Task<bool> ValidateAddressAsync(Address address)
        {
            var client = _httpClientFactory.CreateClient("AddressValidationClient");
            var requestUri = $"https://api.dataforsyningen.dk/adresser?vejnavn={address.Street}&husnr={address.HouseNumber}&etage={address.Floor}&dør={address.DoorNumber}&status=1&struktur=mini";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            // Assume response content should be checked against some criteria to determine validity
            // Here we just check if the response is not empty as a placeholder
            return !string.IsNullOrWhiteSpace(responseContent);

        }

    }
}
