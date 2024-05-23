using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Common.Mappings
{
    public class BookingItemMappingProfile : Profile
    {
        public BookingItemMappingProfile()
        {
            //BookingItemDTO
            CreateMap<BookingItemDTO, BookingItem>().ReverseMap();

            //CreateBookingItemDTO
            CreateMap<CreateBookingItemDTO, BookingItem>().ReverseMap();
        }
    }
}
