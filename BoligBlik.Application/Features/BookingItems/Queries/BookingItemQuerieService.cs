using AutoMapper;
using BoligBlik.Application.DTO;
using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.Interfaces.BookingItems.Queries;
using BoligBlik.Application.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Application.Features.BookingItems.Queries
{
    public class BookingItemQuerieService : IBookingItemQuerieService
    {
        //Dependencies 
        private readonly IBookingItemQuerieRepo _bookingItemsRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<BookingItemQuerieService> _logger;

        public BookingItemQuerieService(IBookingItemQuerieRepo bookingItemsRepo, IMapper mapper, ILogger<BookingItemQuerieService> logger)
        {
            _bookingItemsRepo = bookingItemsRepo;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// reads all booking items
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BookingItemDTO>> ReadAllBookingItemsAsync()
        {

            try
            {
                var bookingItems = await _bookingItemsRepo.ReadAllBookingItemsAsync();
                var bookingitemDTOs = _mapper.Map<IEnumerable<BookingItemDTO>>(bookingItems);

                return bookingitemDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError("something went wrong when reading a boardmember", ex.Message);
                return null;
            }

        }
        /// <summary>
        /// reads a booking item from an id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public async Task<BookingItemDTO> ReadBookingItemAsync(Guid itemId)
        {
            
            try
            {
                var bookingItem = await _bookingItemsRepo.ReadBookingItemsAsync(itemId);
                //map to DTO
                var bookingItemDTO = _mapper.Map<BookingItemDTO>(bookingItem);

                return bookingItemDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("something went wrong when reading a bookingItem", ex.Message);
                return null;
            }
        }
    }
}
