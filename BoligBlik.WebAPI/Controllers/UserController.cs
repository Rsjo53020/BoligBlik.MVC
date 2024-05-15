using AutoMapper;
using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Application.Interfaces.Users.Queries;
using BoligBlik.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCommandService _commandService;
        private readonly IUserQuerieService _querieService;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUserCommandService userCommandService,
            IUserQuerieService userQuerieService, IMapper mapper)
        {
            _commandService = userCommandService;
            _querieService = userQuerieService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] CreateUserDTO request)
        {
            try
            {
                if (request != null)
                {
                    var requestData = _mapper.Map<User>(request);
                    _commandService.CreateUser(requestData);
                    return Created();

                }
                else
                {
                    return BadRequest("Somethingwent wrong");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error creating user with request: {request}, Exception: {ex}");
                return StatusCode(500, "Internal server error");
            }


        }

        [HttpGet("{email}")]
        public async Task<UserDTO> GetUser(string email)
        {
            return await _querieService.ReadUserAsync(email);
        }

        [HttpGet]
        public Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            return _querieService.ReadAllUsersAsync();
        }

        [HttpPut]
        public ActionResult UpdateUser([FromBody] UpdateUserDTO request)
        {
            _commandService.UpdateUser(request);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteUser([FromBody] DeleteUserDTO request)
        {
            _commandService.DeleteUser(request);
            return Ok();
        }
    }
}
