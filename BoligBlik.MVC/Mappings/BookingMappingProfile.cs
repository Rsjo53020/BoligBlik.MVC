using AutoMapper;
using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.Models.BookingItems;
using BoligBlik.MVC.Models.Bookings;

namespace BoligBlik.MVC.Mappings
{
    public class BookingMappingProfile : Profile
    {
        public BookingMappingProfile()
        {
            CreateMap<CreateBookingDTO, CreateBookingViewModel>()
                .ForMember(dest => dest.BookingItem, opt => opt
                    .MapFrom(src => src.BookingItem))
                .ReverseMap();

            CreateMap<BookingViewModel, BookingDTO>().ReverseMap();
        }
    }
}
