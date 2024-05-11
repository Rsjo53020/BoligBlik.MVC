using BoligBlik.Application.Dto.BoardMember;
using BoligBlik.Application.Dto.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardMemberController : ControllerBase
    {
        public BoardMemberController()
        {
            
        }

        [HttpPost]
        public ActionResult PostBoardMember([FromBody] CreateBoardMemberDTO request)
        {
            return Created();
        }

        [HttpGet]
        public BoardMemberDTO GetBoardMember([FromQuery]string title)
        {

        }

        [HttpGet]
        public IEnumerable<BoardMemberDTO> GetAllBoardMembers()
        {

        }

        [HttpPut]
        public ActionResult UpdateBoardMember([FromBody] UpdateBoardmemberDTO request)
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteBoardMember([FromBody]DeleteBoardMemberDTO request)
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult AddUserToMember([FromBody] AddUserToBoardMemberDTO request)
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateBoardmemberParameters([FromBody] UpdateBoardMemberParametersDTO request) 
        {
            return Ok(); 
        }
    }
}
