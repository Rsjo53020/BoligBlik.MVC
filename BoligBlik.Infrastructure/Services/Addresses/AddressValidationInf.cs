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
            _httpClientFactory = httpClientFactory;
        }
        public async Task<bool> ValidateAddressAsync(Address address)
        {
            var client = _httpClientFactory.CreateClient();
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"https://api.dataforsyningen.dk/datavask/adgangsadresser?betegnelse={address.Street} {address.HouseNumber}, {address.PostalcodeNumber} {address.City}");

            // Send anmodningen
            var response = await client.SendAsync(httpRequest);

            // Håndter svar
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

        public Task<IEnumerable<Address>> ValidateAddresssAsync(Address address)
        {
            //string baseUrl = $"https://api.dataforsyningen.dk/datavask/adgangsadresser?betegnelse={address.Street} {address.HouseNumber}, {address.PostalcodeNumber} {address.City}";
            //var addressList = new List<Address>();
            //using (HttpClient client = new HttpClient())
            //{
            //    var response = client.GetAsync(baseUrl).Result;
            //    var json = response.Content.ReadAsStringAsync().Result;
            //    var dataforsyningenResponse = JsonSerializer.Deserialize<AddressDTO>(json);
            //    foreach (var element in dataforsyningenResponse)
            //    {
            //        element.Add(new AddressDTO
            //        {

            //        });
            //    }
            //}

            //return addressList; 
            throw new NotImplementedException();
        }
    }
}
