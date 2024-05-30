using AutoMapper;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Application.Interfaces.Bookings;
using BoligBlik.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using BoligBlik.Persistence.Repositories.Bookings;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Extensions.Logging;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class BookingController : ControllerBase
    {
        //Dependencies
        private readonly IMapper _mapper;
        private readonly IBookingCommandService _bookingCommandService;
        private readonly IBookingQuerieService _bookingQuerieService;
        private readonly Logger<BookingController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bookingQuerie"></param>
        /// <param name="bookingCommand"></param>
        /// <param name="mapper"></param>
        public BookingController(IBookingQuerieService bookingQuerie,
            IBookingCommandService bookingCommand,
            IMapper mapper, Logger<BookingController> logger)
        {
            _bookingQuerieService = bookingQuerie;
            _bookingCommandService = bookingCommand;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Create Booking from DTO.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] CreateBookingDTO request)
        {
            try
            {
                _bookingCommandService.CreateBooking(request);
                return Created();
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error"); 
            }
        }

        /// <summary>
        /// Read Booking from BookingId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> GetBookingAsync(Guid id)
        {
            try
            {
                var booking = await _bookingQuerieService.ReadBookingAsync(id);
                if (booking == null)
                {
                    _logger.LogError($"Booking with id {id} not found");
                }
                return Ok(booking); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Get All bookings.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAllBookingsAsync()
        {
            try
            {
                var result = await _bookingQuerieService.ReadAllBookingAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Delete Booking by bookingId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{rowVersion}")]
        public IActionResult DeleteBooking(Guid id, string rowVersion)
        {
            try
            {
                _bookingCommandService.DeleteBooking(id, Convert.FromBase64String(rowVersion));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Update Booking by BookingDTO
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult UpdateBooking([FromBody] BookingDTO request)
        {
            try
            {
                _bookingCommandService.UpdateBooking(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

