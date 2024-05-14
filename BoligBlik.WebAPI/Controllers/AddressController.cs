using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.Interfaces.Addresses.Commands;
using BoligBlik.Application.Interfaces.Addresses.Queries;
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
        public AddressController(IAddressCommandService addressCommandService,
            IAddressQuerieService addressQuerieService)
        {
            _addressCommandService = addressCommandService;
            _addressQuerieService = addressQuerieService;
        }
        // POST api/<Address>
        [HttpPost]
        public void Post([FromBody] AddressDTO request)
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
