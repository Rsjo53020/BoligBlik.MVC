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
            //CreateMap<CreateBookingDTO, Booking>()
            //    .ConstructUsing((src, context) =>
            //    {
            //        var bookingItem = context.Mapper.Map<BookingItem>(src.Item);
            //        return new Booking(src.StartTime, src.EndTime, bookingItem);
            //    })
            //    .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.Item))


            //    .ForPath(dest => dest.Item, act => act
            //        .MapFrom(src => src.Item))

            //    .ForPath(dest => dest.BookingDates.startTime, act => act
            //        .MapFrom(scr => scr.StartTime))

            //    .ForPath(dest => dest.BookingDates.endTime, act => act
            //        .MapFrom(scr => scr.EndTime))
            //    .ReverseMap();


            //BookingDTO
            CreateMap<BookingDTO, Booking>()
                .ForPath(dest => dest.BookingDates.startTime, act => act
                    .MapFrom(scr => scr.StartTime))
                .ForPath(dest => dest.BookingDates.endTime, act => act
                    .MapFrom(scr => scr.EndTime))
                .ReverseMap();

            
        }
    }
}
