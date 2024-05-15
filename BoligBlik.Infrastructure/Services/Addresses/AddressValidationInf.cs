using BoligBlik.Application.Interfaces.Infrastructure;
using BoligBlik.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using BoligBlik.Application.DTO.Adress;
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
            var client = _httpClientFactory.CreateClient();
            var httpClient = new HttpClient();
            var BaseAddress = new HttpRequestMessage(HttpMethod.Get, $"https://api.dataforsyningen.dk/adresser?vejnavn={address.Street}&husnr={address.HouseNumber}&etage={address.Floor}&dør={address.DoorNumber}&status=1&struktur=mini");
            var response = await httpClient.SendAsync(BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<Address>(responseContent);

                return result != null;
            }
            else
            {
                var statusCode = response.StatusCode;
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Request failed with status code {statusCode}. Error message: {errorMessage}");
            }
        }

    }
}
