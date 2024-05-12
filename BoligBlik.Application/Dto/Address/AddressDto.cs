using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.DTO.Adress
{
    public class AddressDTO
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Floor { get; set; }
        public string Side { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
