using AutoMapper;
using BoligBlik.Application.DTO;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.Interfaces.BookingItems.Queries;
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
        public async Task<IEnumerable<BookingItemDTO>> ReadAllBookingItemsAsync()
        {
            var bookingItems = await _bookingItemsRepo.ReadAllBookingItemsAsync();
            return _mapper.Map<IEnumerable<BookingItemDTO>>(bookingItems);
        }

        public async Task<BookingItemDTO> ReadBookingItemAsync(Guid itemId)
        {
            var bookingItem = await _bookingItemsRepo.ReadBookingItemsAsync(itemId);
            return _mapper.Map<BookingItemDTO>(bookingItem);
        }
    }
}
