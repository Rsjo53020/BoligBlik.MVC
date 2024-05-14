using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.Interfaces.BookingItems.Queries;
using BoligBlik.Application.Interfaces.Bookings;
using BoligBlik.Application.Interfaces.Repositories;

namespace BoligBlik.Application.Features.BookingItems.Queries
{
    public class BookingItemQuerieService : IBookingItemQuerieService
    {
        //Dependencies 
        private readonly IBookingItemQuerieRepo _bookingItemsRepo;
        private readonly IMapper _mapper;

        public BookingItemQuerieService(IBookingItemQuerieRepo bookingItemsRepo, IMapper mapper)
        {
            _bookingItemsRepo = bookingItemsRepo;
            _mapper = mapper;
        }
        public async Task<BookingItemDTO> ReadBookingItemAsync(string name)
        {
            var bookingItem = await _bookingItemsRepo.ReadBookingItemsAsync(name);
            return _mapper.Map<BookingItemDTO>(bookingItem);
        }
        public async Task<IEnumerable<BookingItemDTO>> ReadAllBookingItemsAsync()
        {
            var bookingItems = await _bookingItemsRepo.ReadAllBookingItemsAsync();
            return _mapper.Map<IEnumerable<BookingItemDTO>>(bookingItems);
        }
    }
}
