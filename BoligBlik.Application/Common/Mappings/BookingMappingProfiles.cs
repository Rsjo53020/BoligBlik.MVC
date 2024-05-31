using AutoMapper;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Entities;
using BoligBlik.Entities;

namespace BoligBlik.Application.Common.Mappings
{
    public class BookingMappingProfiles : Profile
    {
        public BookingMappingProfiles()
        {
            CreateMap<BookingDTO, Booking>()
                       .ForPath(dest => dest.BookingDates.startTime, act => act.MapFrom(src => src.StartTime))
                       .ForPath(dest => dest.BookingDates.endTime, act => act.MapFrom(src => src.EndTime))
                       .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item))
                       .ReverseMap();
        }
    }
}
