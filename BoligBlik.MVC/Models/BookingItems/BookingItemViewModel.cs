using BoligBlik.MVC.DTO.BookingItems;

namespace BoligBlik.MVC.Models.BookingItems
{
    public class BookingItemViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
    }
}
