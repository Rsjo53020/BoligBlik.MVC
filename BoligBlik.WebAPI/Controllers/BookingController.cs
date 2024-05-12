using AutoMapper;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.DTO.Booking;
using BoligBlik.Application.Interfaces.Booking;
using BoligBlik.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace BoligBlik.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBookingCommandService _bookingCommand;
        private readonly IBookingQuerieService _bookingQuerie;


        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(CreateBookingDTO createBookingDTO)
        {
            try
            {
                _bookingCommand.CreateBooking(createBookingDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("id")]
        public IActionResult GetBooking([FromQuery] BookingDTO id)
        {
            try
            {
                _bookingQuerie.ReadBooking(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("All")]
        public ActionResult<IEnumerable<BookingDTO>> GetAllBoardMembers()
        {
            try
            {
                _bookingQuerie.ReadAllBooking();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpPut("updateBooking")]
        public ActionResult UpdateBooking([FromBody] UpdateBookingDTO updateBookingDto)
        {
            try
            {
                _bookingCommand.UpdateBooking(updateBookingDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete]
        public IActionResult DeleteBooking([FromBody] DeleteBookingDTO deleteBookingDto)
        {
            try
            {
                _bookingCommand.DeleteBooking(deleteBookingDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}

