using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.BookingItems
{
    public class BookingItemDTO : IEntity
    {
        public string Name { get; set; }
        public Decimal? Price { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public string Repairs { get; set; }
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
