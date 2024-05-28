using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.Models.Common;

namespace BoligBlik.MVC.Models.BookingItems
{
    public class BookingItemViewModel : EntityViewModel
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public string Repairs { get; set; }
    }
}
