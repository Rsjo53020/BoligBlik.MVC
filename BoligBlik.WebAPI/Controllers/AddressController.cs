using AutoMapper;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Application.Interfaces.Addresses.Commands;
using BoligBlik.Application.Interfaces.Addresses.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class AddressController : ControllerBase
    {
        //Dependencies
        private readonly IAddressCommandService _addressCommandService;
        private readonly IAddressQuerieService _addressQuerieService;
        private readonly ILogger<AddressController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="addressCommandService"></param>
        /// <param name="addressQuerieService"></param>
        /// <param name="mapper"></param>
        public AddressController(IAddressCommandService addressCommandService, IAddressQuerieService addressQuerieService,
            ILogger<AddressController> logger)
        {
            _addressCommandService = addressCommandService;
            _addressQuerieService = addressQuerieService;
            _logger = logger;
        }

        /// <summary>
        /// Create Address 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] CreateAddressDTO request)
        {

            try
            {
                if (request != null)
                {
                    _addressCommandService.CreateAddress(request);
                    return Created();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating address with request: {request}, Exception: {ex}");
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get Adress by AdressId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetAddressAsync(Guid id)
        {
            try
            {
                var address = await _addressQuerieService.ReadAddressAsync(id);
                return Ok(address);

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in read a address with id: {id}, Exception: {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Get all Adresses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<AddressDTO>> GetAllAddressesAsync()
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

        /// <summary>
        /// Update Adress 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateAddress([FromBody] UpdateAddressDTO request)
        {
            try
            {
                if (request != null)
                {
                    _addressCommandService.UpdateAddress(request);
                    return Ok(request);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
