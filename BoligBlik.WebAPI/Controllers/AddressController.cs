using AutoMapper;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.Interfaces.Addresses.Commands;
using BoligBlik.Application.Interfaces.Addresses.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressCommandService _addressCommandService;
        private readonly IAddressQuerieService _addressQuerieService;
        private readonly ILogger<AddressController> _logger;
        private readonly IMapper _mapper;
        public AddressController(IAddressCommandService addressCommandService, IAddressQuerieService addressQuerieService, IMapper mapper)
        {
            _addressCommandService = addressCommandService;
            _addressQuerieService = addressQuerieService;
            _mapper = mapper;
        }
        // POST api/<Address>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAddressDTO request)
        {
             try
            {
                _addressCommandService.CreateAddress(request);
                return Ok(request);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddress([FromQuery] AddressDTO request)
        {
            try
            {
                //var resultat = await _addressQuerieService.ReadAddress(request);
               return Ok();

                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> Get()
        {
            try
            {
                var resultat = await _addressQuerieService.ReadAllAsync();
                return Ok(resultat);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBooking(Guid id, [FromBody] UpdateAddressDTO updateAddressDto)
        {
            if (id != updateAddressDto.Id)
            {
                return BadRequest();
            }

            _addressCommandService.UpdateAddress(updateAddressDto);

            return Ok(updateAddressDto);
        }


    }
}
