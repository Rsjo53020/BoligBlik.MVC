using AutoMapper;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.DTO.Bookings;
using BoligBlik.Application.Interfaces.Bookings;
using BoligBlik.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BoligBlik.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
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

        [HttpPost("Create")]
        //[Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateBookingDTO createBookingDTO)
        {
            try
            {
              _bookingCommand.CreateBooking(createBookingDTO);
                return Ok(createBookingDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDTO>> GetBooking([FromQuery] BookingDTO id)
        {
            try
            {
                
                return await _bookingQuerie.ReadBooking(id);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(Guid id, [FromBody] BookingDTO updateBookingDto)
        {
            if (id != updateBookingDto.Id)
            {
                return BadRequest();
            }
            
            _bookingCommand.UpdateBooking(updateBookingDto);

            return Ok(updateBookingDto);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooking([FromBody] BookingDTO deleteBookingDto)
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

