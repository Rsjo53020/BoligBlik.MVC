using BoligBlik.MVC.DTO.Common;

namespace BoligBlik.MVC.DTO.BookingItems
{
    public class BookingItemDTO : EntityDTO
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public string Repairs { get; set; }
    }
}
