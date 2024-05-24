using AutoMapper;
using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Application.Interfaces.Users.Queries;
using BoligBlik.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

                    _commandService.CreateUser(request);
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
            var restult = await _querieService.ReadUserAsync(email);
            return restult;
        }

        //[HttpGet("{id}")]
        //public async Task<UserDTO> GetUser(Guid id)
        //{
        //    var restult = await _querieService.ReadUserAsync(id);
        //    return restult;
        //}


        [HttpGet]
        public Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            return _querieService.ReadAllUsersAsync();
        }

        [HttpPut]
        public ActionResult UpdateUser([FromBody] UserDTO request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _commandService.UpdateUser(request);
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError($"Concurrency conflict while updating user with request: {request}, Exception: {ex}");
                return StatusCode(409, "Concurrency conflict occurred. Please try again.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating user with request: {request}, Exception: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete]
        public ActionResult DeleteUser([FromBody] UserDTO request)
        {
            _commandService.DeleteUser(request);
            return Ok();
        }
    }
}
