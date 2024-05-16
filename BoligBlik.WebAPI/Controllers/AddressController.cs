using AutoMapper;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.Interfaces.Addresses.Commands;
using BoligBlik.Application.Interfaces.Addresses.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public AddressController(IAddressCommandService addressCommandService,
            IAddressQuerieService addressQuerieService, IMapper mapper)
        {
            _addressCommandService = addressCommandService;
            _addressQuerieService = addressQuerieService;
            _mapper = mapper;
        }
        // POST api/<Address>
        [HttpPost]
        public void Post([FromBody] CreateAddressDTO request)
        {
           _addressCommandService.Create(request);
        }
        [HttpGet]
        public async Task<IEnumerable<AddressDTO>> Get()
        {
            return await _addressQuerieService.ReadAllAsync();
        }

    }
}
