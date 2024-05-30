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
        //services
        private readonly IBookingItemCommandService _bookItemCommandService;
        private readonly IBookingItemQuerieService _bookItemQuerieService;
        //logger
        private readonly ILogger<BookingItemsController> _logger;

        public BookingItemsController(IBookingItemCommandService bookingItemCommandService,
            IBookingItemQuerieService bookingItemQuerieService,
            ILogger<BookingItemsController> logger)
        {
            _bookItemCommandService = bookingItemCommandService;
            _bookItemQuerieService = bookingItemQuerieService;
            _logger = logger;
        }
        /// <summary>
        /// creates a booking item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostBookingItem([FromBody] CreateBookingItemDTO request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bookItemCommandService.CreateBookingItem(request);
                    return Created();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("sommething went wrong when creating bookingitem", ex.Message);
                return StatusCode(500, ex);
            }

        }
        /// <summary>
        /// reads all booking items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllBookingItems()
        {
            try
            {
                var result = await _bookItemQuerieService.ReadAllBookingItemsAsync();
                if (result == null) return BadRequest();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("sommething went wrong when reading bookingitems", ex.Message);
                return StatusCode(500, ex);
            }
        }
        /// <summary>
        /// reads a booking item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet("{itemId}")]
        public async Task<ActionResult> GetBookingItem(Guid itemId)
        {
            try
            {
                if (itemId == null) return BadRequest();
                var result = await _bookItemQuerieService.ReadBookingItemAsync(itemId);
                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("sommething went wrong when reading bookingitem", ex.Message);
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// updates a booking item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult UpdateBookingItem([FromBody] BookingItemDTO request)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    _bookItemCommandService.UpdateBookingItem(request);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("sommething went wrong when updating bookingitem", ex.Message);
                return StatusCode(500, ex);
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
            try
            {
                if (id == Guid.Empty || rowVersion == null) return BadRequest();
                _bookItemCommandService.DeleteBookingItem(id, Convert.FromBase64String(rowVersion));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("sommething went wrong when delete bookingitem", ex.Message);
                return StatusCode(500, ex);
            }
        }


    }
}
