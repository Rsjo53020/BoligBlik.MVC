namespace BoligBlik.MVC.Models.BookingItems
{
    public class CreateBookingItemViewModel
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string Rules { get; set; }
        public string Repairs { get; set; }
    }
}
