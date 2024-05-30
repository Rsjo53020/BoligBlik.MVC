using AutoMapper;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Application.Interfaces.Addresses.Commands;
using BoligBlik.Application.Interfaces.Addresses.Queries;
using BoligBlik.Application.Interfaces.Users.Queries;
using Microsoft.AspNetCore.Mvc;

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
            if (request is null) return BadRequest();

            try
            {

                _addressCommandService.CreateAddress(request);
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating address with request: {request}, Exception: {ex}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddress(Guid id)
        {
            try
            {

                var address = await _addressQuerieService.ReadAddress(id);
                return Ok(address);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in read a address with id: {id}, Exception: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public async Task<IEnumerable<AddressDTO>> GetAllAddresses()
        {
            try
            {
                var response = await _addressQuerieService.ReadAllAsync();
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in reading all addresses at {DateTime.UtcNow}, Exception: {ex}");
                return new List<AddressDTO>();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] AddressDTO request)
        {

            try
            {
                _addressCommandService.UpdateAddress(request);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public ActionResult DeleteAddress([FromBody] AddressDTO request)
        {
            _addressCommandService.DeleteAddress(request);
            return Ok();
        }

        //[HttpGet("useraddress/{userId}")]
        //public async Task<ActionResult<AddressDTO>> GetUserAddress(Guid userId)
        //{
        //    try
        //    {
        //        var addressDTO = await _addressQuerieService.GetUserAddress(userId);
        //        if (addressDTO == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(addressDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error in reading an address with id: {userId}, Exception: {ex.Message}");
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}
