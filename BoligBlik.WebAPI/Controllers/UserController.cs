using BoligBlik.Application.Dto.User;
using BoligBlik.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BoligBlik.Application.Interfaces.Repositories;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")] 
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserDto request)
        {
            await _userService.CreateUserAsync(request);
            return Ok();
        }

        [HttpPut("update")] 
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserDto request)
        {
            await _userService.UpdateUserAsync(request);
            return Ok();
        }

        [HttpDelete("{email}")] 
        public async Task<IActionResult> DeleteUserAsync(string email)
        {
            await _userService.DeleteUserAsync(email);
            return Ok();
        }

        [HttpGet("all")] 
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{email}")] 
        public async Task<IActionResult> GetUserAsync(string email)
        {
            var user = await _userService.GetUserAsync(email);
            return Ok(user);
        }
    }
}