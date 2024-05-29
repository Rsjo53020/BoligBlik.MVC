using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using BoligBlik.Application.Interfaces.Infrastructure;
using BoligBlik.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
            var dawaAddress = $"{address.Street} {address.HouseNumber}, {address.Floor}, {address.DoorNumber}, {address.PostalCode.PostalcodeNumber} {address.PostalCode.City}&status=1&struktur=mini";


            var client = _httpClientFactory.CreateClient("AddressValidationClient");
            var requestUri = $"https://api.dataforsyningen.dk/datavask/adresser?betegnelse={dawaAddress}";
            var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = response.Content.ReadAsStringAsync().Result;
            var responseObject = JObject.Parse(responseContent);

            var kategori = responseObject["kategori"]?.ToString();

            return kategori switch
            {
                "A" => true,
                "B" => false,
                "C" => false,
                _ => false,
            };

        }

    }
}
