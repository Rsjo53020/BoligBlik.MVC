using AutoMapper;
using BoligBlik.Application.Dto.Booking;
using BoligBlik.Application.Interfaces;
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

        
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(CreateBookingDto createBookingDto)
        {
            try
            {
                _bookingCommand.CreateBooking(createBookingDto);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
          
        }

       
        
    }
}
