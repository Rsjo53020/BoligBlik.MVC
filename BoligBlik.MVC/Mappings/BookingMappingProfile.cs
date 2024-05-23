using AutoMapper;
using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.Models.Bookings;

namespace BoligBlik.MVC.Mappings
{
    public class BookingMappingProfile : Profile 
    {
        public BookingMappingProfile()
        {
            CreateMap<BookingDTO, BookingViewModel>().ReverseMap();
            CreateMap<CreateBookingDTO, CreateBookingViewModel>().ReverseMap();
        }
    }
}
