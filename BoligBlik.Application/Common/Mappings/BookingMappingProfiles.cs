using AutoMapper;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Common.Mappings
{
    public class BookingMappingProfiles : Profile
    {
        public BookingMappingProfiles()
        {
            //CreateUserDTO
            CreateMap<CreateBookingDTO, Booking>();
            CreateMap<Booking, CreateBookingDTO>();

            //DeleteBookingDTO
            CreateMap<DeleteBookingDTO, Booking>();
            CreateMap<Booking, DeleteBookingDTO>();

            //UpdateBookingDTO
            CreateMap<UpdateBookingDTO, Booking>();
            CreateMap<Booking, UpdateBookingDTO>();

            //BookingDTO
            CreateMap<BookingDTO, Booking>();
            CreateMap<Booking, BookingDTO>();
        }
    }
}
