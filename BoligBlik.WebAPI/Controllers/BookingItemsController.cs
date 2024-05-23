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

        [HttpPost]
        public ActionResult PostBookingItem([FromBody] CreateBookingItemDTO request)
        {
            _bookItemCommandService.CreateBookingItem(request);
            return Created();
        }

        [HttpGet]
        public async Task<BookingItemDTO> GetBookingItem([FromQuery] string name)
        {
            return await _bookItemQuerieService.ReadBookingItemAsync(name);
        }

        [HttpGet("{itemId}")]
        public async Task<BookingItemDTO> GetBookingItem(Guid itemId)
        {
            return await _bookItemQuerieService.ReadBookingItemAsync(itemId);
        }

        [HttpPut]
        public ActionResult UpdateBookingItem([FromBody] UpdateBookingItemDTO request)
        {
            _bookItemCommandService.UpdateBookingItem(request);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteBookingItem([FromBody] DeleteBookingItemDTO request)
        {
            _bookItemCommandService.DeleteBookingItem(request);
            return Ok();
        }

        [HttpGet("All")]
        public async Task<IEnumerable<BookingItemDTO>> GetAllBookingItems()
        {
            return await _bookItemQuerieService.ReadAllBookingItemsAsync();
        }
    }
}
