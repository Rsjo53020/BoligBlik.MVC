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
            CreateMap<BookingItemDTO, BookingItemViewModel>();
            CreateMap<BookingItemViewModel, BookingItemDTO>();

            CreateMap<BookingDTO, CreateBookingViewModel>()
                .ForMember(dest => dest.BookingItem, opt => opt.MapFrom(src => src.BookingItem)); // Map BookingDTO to CreateBookingViewModel

            CreateMap<CreateBookingViewModel, BookingDTO>()
                .ForMember(dest => dest.BookingItem, opt => opt.MapFrom(src => src.BookingItem)); // Reverse map CreateBookingViewModel to BookingDTO

            CreateMap<CreateBookingViewModel, CreateBookingDTO>(); 
        }
    }
}
