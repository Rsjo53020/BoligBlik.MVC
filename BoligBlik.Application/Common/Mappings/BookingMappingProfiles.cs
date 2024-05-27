using AutoMapper;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Common.Mappings
{
    public class BookingMappingProfiles : Profile
    {
        public BookingMappingProfiles()
        {
            //CreateUserDTO
            CreateMap<CreateBookingDTO, Booking>().ReverseMap();

            //BookingDTO
            CreateMap<BookingDTO, Booking>()
                .ForPath(dest => dest.BookingDates.startTime, act => act
                    .MapFrom(scr => scr.StartTime))
                .ForPath(dest => dest.BookingDates.endTime, act => act
                    .MapFrom(scr => scr.EndTime))
                .IncludeBase<BookingItemDTO ,BookingItem >().ReverseMap();
        }
    }
}
