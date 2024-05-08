using BoligBlik.Application.DTOs.User;
using BoligBlik.Application.Features.User.Commands.Interfaces;
using BoligBlik.Application.Features.User.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPI : ControllerBase
    {
        //Properties
        private readonly ILogger _logger;
        private readonly IUserCreate _userCreate;
        private readonly IUserGet _userGet;
        private readonly IUserGetAll _userGetAll;
        private readonly IUserUpdate _userUpdate;
        private readonly IUserDelete _userDelete;

        public UserAPI(ILogger logger, IUserCreate userCreate, IUserGet userGet, IUserGetAll userGettAll,
            IUserUpdate userUpdate, IUserDelete userDelete)
        {

            _logger = logger;
            _userCreate = userCreate;
            _userGet = userGet;
            _userGetAll = userGettAll;
            _userUpdate = userUpdate;
            _userDelete = userDelete;

        }
        [HttpPost()]
        public ActionResult PostUser(UserRequestDTO request)
        {
            try
            {
                _userCreate.Create(request);
                return Created();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not create User",ex);
                return BadRequest();
            }
                
            
        }

        [HttpGet("{email}")]
        public UserGetDTO GetUser([FromQuery]string email)
        {
            var result = _userGet.Read(email);
            return result;
        }

        [HttpGet()]
        public IEnumerable<UserGetDTO> GetAllUsers() 
        {
            var result = _userGetAll.ReadAll();
            return result;
        }

        [HttpPut()]
        public ActionResult PutUser([FromBody]UserRequestDTO request)
        {
            try
            {
                _userUpdate.Update(request);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError("Could not update User", ex);
                return BadRequest();
            }
        }

        [HttpDelete()]
        public ActionResult DeleteUser([FromBody]Guid Id) 
        {
            try
            { 
                _userDelete.Delete(Id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError("Could not delete user", ex);
                return BadRequest();
            }
        }
    }
}
