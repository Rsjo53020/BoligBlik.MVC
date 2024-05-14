using BoligBlik.Application.Interfaces.Infrastructure;
using BoligBlik.Domain.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Infrastructure.Services.Addresses
{
    public class AddressValidationInf : IAddressValidationInf
    {
        public async Task<bool> ValidateAddressAsync(Address address)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.dataforsyningen.dk/datavask/adgangsadresser?betegnelse=buen 102, 6200 aabenraa");
            var content = new StringContent("", null, "text/plain");
            request.Content = content;
            //send
            var response = await client.SendAsync(request);
            //svar
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }
    }
}
