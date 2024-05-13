using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Domain.Entities
{
    public class Item : Entity
    {
        [Required]
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public string Repairs { get; set; }
        public Byte[] Image { get; set; }

        public Item() : base()
        {
            
        }
    }
}
