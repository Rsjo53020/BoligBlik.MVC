using Azure.Core;
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
        //Dependencies
        private readonly IBookingItemCommandService _bookItemCommandService;
        private readonly IBookingItemQuerieService _bookItemQuerieService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bookingItemCommandService"></param>
        /// <param name="bookingItemQuerieService"></param>
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
            if (request == null) return BadRequest();
            _bookItemCommandService.CreateBookingItem(request);
            return Created();
        }
        /// <summary>
        /// reads all booking items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllBookingItems()
        {
            var result = await _bookItemQuerieService.ReadAllBookingItemsAsync();
            if(result == null) return BadRequest();
            return Ok(result);
        }
        /// <summary>
        /// reads a booking item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet("{itemId}")]
        public async Task<ActionResult> GetBookingItemAsync(Guid itemId)
        {
            if (itemId == null) return BadRequest();
            var result = await _bookItemQuerieService.ReadBookingItemAsync(itemId);
            if(result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// updates a booking item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult UpdateBookingItem([FromBody] BookingItemDTO request)
        {
            if (request == null) return BadRequest();
            try
            {
                _bookItemCommandService.UpdateBookingItem(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        /// <summary>
        /// deletes a booking item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{rowVersion}")]
        public ActionResult DeleteBookingItem(Guid id, string rowVersion)
        {
            _bookItemCommandService.DeleteBookingItem(id, Convert.FromBase64String(rowVersion));
            return Ok();
        }


    }
}
