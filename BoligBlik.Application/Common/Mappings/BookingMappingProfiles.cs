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
        private readonly IBookingDomainService _bookingDomainService;
        public BookingMappingProfiles()
        {
            //CreateUserDTO
            CreateMap<CreateBookingDTO, Booking>().ConstructUsing((src, context) =>
                    new Booking(src.StartTime, src.EndTime, context.Mapper.Map<BookingItem>(src.BookingItem), context.Mapper.Map<Address>(src.Address), _bookingDomainService))

                .ForPath(dest => dest.Item, act => act
                    .MapFrom(src => src.BookingItem))

                .ForPath(dest => dest.BookingDates.startTime, act => act
                    .MapFrom(scr => scr.StartTime))

                .ForPath(dest => dest.BookingDates.endTime, act => act
                    .MapFrom(scr => scr.EndTime))
                .ReverseMap();


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
