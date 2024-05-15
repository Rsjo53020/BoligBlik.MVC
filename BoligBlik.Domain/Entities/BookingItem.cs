using System.ComponentModel.DataAnnotations;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Domain.Entities
{
    public class BookingItem : Entity
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public string Repairs { get; set; }
        public string ImageFilePath { get; set; }

        public BookingItem() : base()
        {
            
        }
    }
}
