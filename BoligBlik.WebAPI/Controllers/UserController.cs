using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Application.Interfaces.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCommandService _commandService;
        private readonly IUserQuerieService _querieService;

        public UserController(IUserCommandService userCommandService,
            IUserQuerieService userQuerieService)
        {
            _commandService = userCommandService;
            _querieService = userQuerieService;
        }

        [HttpPost]
        public ActionResult PostUser([FromBody] CreateUserDTO request)
        {
            _commandService.CreateUser(request);
            return Created();
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
