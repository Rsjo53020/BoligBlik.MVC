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

namespace BoligBlik.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBookingCommandService _bookingCommand;
        private readonly IBookingQuerieService _bookingQuerie;

        public BookingController(IBookingQuerieService bookingQuerie, IBookingCommandService bookingCommand, IMapper mapper)
        {
            _bookingQuerie = bookingQuerie;
            _bookingCommand = bookingCommand;
            _mapper = mapper;
        }

        [HttpPost]
        //[Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateBookingDTO request)
        {
            try
            {
              _bookingCommand.CreateBooking(request);
                return Ok(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> GetBooking(Guid id)
        {
            try
            {
                var booking = await _bookingQuerie.ReadBooking(id);
                if (booking == null)
                {
                    return NotFound();
                }
                return Ok(booking);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAllBookingsAsync()
        {
            try
            {
                var result = await _bookingQuerie.ReadAllBooking();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id}/{rowVersion}")]
        public IActionResult DeleteBooking(Guid id, string rowVersion)
        {
            try
            {
                _bookingCommand.DeleteBooking(id, Convert.FromBase64String(rowVersion));
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateBooking([FromBody] BookingDTO request)
        {
            try
            {
                _bookingCommand.UpdateBooking(request);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

