using AutoMapper;
using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.Models.BookingItems;


namespace BoligBlik.MVC.Mappings
{
    public class BookingItemMappingProfile : Profile
    {
        public BookingItemMappingProfile()
        {
            CreateMap<BookingItemDTO, BookingItemViewModel>().ReverseMap();
            CreateMap<CreateBookingItemDTO, CreateBookingItemViewModel>().ReverseMap();
        }
    }
}
