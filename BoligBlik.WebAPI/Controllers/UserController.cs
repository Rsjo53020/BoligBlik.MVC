﻿using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Application.Interfaces.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.WebAPI.Controllers
{
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

        [HttpPost("Create User")]
        public ActionResult PostUser([FromBody] CreateUserDTO request)
        {
            _commandService.CreateUserAsync(request);
            return Created();
        }

        [HttpGet("Get User")]
        public UserDTO GetUser([FromQuery] string email)
        {
            return _querieService.ReadUser(email);
        }

        [HttpGet("Get Users")]
        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _querieService.ReadAllUsers();
        }

        [HttpPut("Update User")]
        public ActionResult UpdateUser([FromBody] UpdateUserDTO request)
        {
            _commandService.UpdateUserAsync(request);
            return Ok();
        }

        [HttpDelete("Delete User")]
        public ActionResult DeleteUser([FromBody] DeleteUserDTO request)
        {
            _commandService.DeleteUserAsync(request);
            return Ok();
        }
    }
}
