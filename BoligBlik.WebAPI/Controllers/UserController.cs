using AutoMapper;
using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Application.Interfaces.Users.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //services
        private readonly IUserCommandService _commandService;
        private readonly IUserQuerieService _querieService;
        //logger
        private readonly ILogger<UserController> _logger;
        //mapper
        private readonly IMapper _mapper;

        public UserController(IUserCommandService userCommandService,
            IUserQuerieService userQuerieService, IMapper mapper)
        {
            _commandService = userCommandService;
            _querieService = userQuerieService;
            _mapper = mapper;
        }
        /// <summary>
        /// Creates a user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
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
                    return BadRequest("Something went wrong");
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Error creating user", ex.Message);
                return StatusCode(500, "Internal server error");
            }


        }
        /// <summary>
        /// reads a user from email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("{email}")]
        public async Task<ActionResult> GetUser(string email)
        {
            if (string.IsNullOrEmpty(email)) return BadRequest();
            var restult = await _querieService.ReadUserAsync(email);

            if (restult == null) return NotFound();
            return Ok(restult);
        }

        /// <summary>
        /// reads all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var result = await _querieService.ReadAllUsersAsync();

            if (result == null) return NotFound();
            return Ok(result);
        }
        /// <summary>
        /// updates a user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult UpdateUser([FromBody] UserDTO request)
        {

            try
            {
                if (request == null)
                {
                    return BadRequest("Request cannot be null.");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _commandService.UpdateUser(request);
                return Ok();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError("Concurrency conflict while updating user with request", ex.Message);
                return StatusCode(409, "Concurrency conflict occurred. Please try again.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error updating user with request", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// deletes a user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{rowVersion}")]
        public ActionResult DeleteUser(Guid id, string rowVersion)
        {
            try
            {
                _commandService.DeleteUser(id, Convert.FromBase64String(rowVersion));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error deleting user with request", ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
