using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Value;

namespace BoligBlik.Domain.Entities
{
    public class Property
    {
        [Required]
        public User BoardManager { get; set; }
        public List<Address> Addresses { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
