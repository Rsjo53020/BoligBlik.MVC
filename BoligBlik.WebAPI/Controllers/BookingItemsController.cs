using BoligBlik.Application.DTO.BookingItems;
using BoligBlik.Application.Interfaces.BookingItems.Commands;
using BoligBlik.Application.Interfaces.BookingItems.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingItemsController : ControllerBase
    {
        private readonly IBookingItemCommandService _bookItemCommandService;
        private readonly IBookingItemQuerieService _bookItemQuerieService;

        public BookingItemsController(IBookingItemCommandService bookingItemCommandService,
            IBookingItemQuerieService bookingItemQuerieService)
        {
            _bookItemCommandService = bookingItemCommandService;
            _bookItemQuerieService = bookingItemQuerieService;
        }
        /// <summary>
        /// creates a booking item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostBookingItem([FromBody] CreateBookingItemDTO request)
        {
            _bookItemCommandService.CreateBookingItem(request);
            return Created();
        }
        /// <summary>
        /// reads all booking items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<BookingItemDTO>> GetAllBookingItems()
        {
            return await _bookItemQuerieService.ReadAllBookingItemsAsync();
        }
        /// <summary>
        /// reads a booking item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet("{itemId}")]
        public async Task<BookingItemDTO> GetBookingItem(Guid itemId)
        {
            return await _bookItemQuerieService.ReadBookingItemAsync(itemId);
        }

        /// <summary>
        /// updates a booking item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult UpdateBookingItem([FromBody] BookingItemDTO request)
        {
            _bookItemCommandService.UpdateBookingItem(request);
            return Ok();
        }
        /// <summary>
        /// deletes a booking item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{rowVersion}")]
        public ActionResult DeleteBookingItem(Guid id, Byte[] rowVersion)
        {
            _bookItemCommandService.DeleteBookingItem(id,rowVersion);
            return Ok();
        }


    }
}
