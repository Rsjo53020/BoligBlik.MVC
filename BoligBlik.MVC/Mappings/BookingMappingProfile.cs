using AutoMapper;
using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.Models.Bookings;

namespace BoligBlik.MVC.Mappings
{
    public class BookingMappingProfile : Profile 
    {
        public BookingMappingProfile()
        {
            CreateMap<BookingDTO, CreateBookingDTO>().ReverseMap();
            CreateMap<BookingDTO, UpdateBookingViewModel>().ReverseMap();
            CreateMap<BookingDTO, DeleteBookingViewModel>().ReverseMap();

            CreateMap<CreateBookingDTO, CreateBookingViewModel>().ReverseMap();
            
        }
    }
}
