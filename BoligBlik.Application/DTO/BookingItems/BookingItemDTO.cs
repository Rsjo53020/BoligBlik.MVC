using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Common.Entity;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.BookingItems
{
    public class BookingItemDTO : EntityDTO
    {
        [StringLength(50)]
        public string Name { get; set; }
        public Decimal? Price { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public string Repairs { get; set; }
    }
}
