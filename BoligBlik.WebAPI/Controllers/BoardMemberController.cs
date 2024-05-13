using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.Interfaces.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.BoardMembers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardMemberController : ControllerBase
    {
        private readonly IBoardMemberCommandService _commandService;
        private readonly IBoardMemberQuerieService _querieService;
        public BoardMemberController(IBoardMemberCommandService boardMemberCommandService,
            IBoardMemberQuerieService boardMemberQuerieService)
        {
            _commandService = boardMemberCommandService;
            _querieService = boardMemberQuerieService;
        }

        [HttpPost]
        public ActionResult PostBoardMember([FromBody] CreateBoardMemberDTO request)
        {
            _commandService.CreateBoardMember(request);
            return Created();
        }

        [HttpGet("{title}")]
        public BoardMemberDTO GetBoardMember([FromQuery]string title)
        {
            return _querieService.ReadBoardMember(title);
        }

        [HttpGet()]
        public IEnumerable<BoardMemberDTO> GetAllBoardMembers()
        {
            return _querieService.ReadAllBoardMembers();
        }

        [HttpPut("updateMember")]
        public ActionResult UpdateBoardMember([FromBody] UpdateBoardMemberDTO request)
        {
            _commandService.UpdateBoardMember(request);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteBoardMember([FromBody]DeleteBoardMemberDTO request)
        {
            _commandService.DeleteBoardMember(request);
            return Ok();
        }

        [HttpPut("newMember")]
        public ActionResult AddUserToMember([FromBody] AddUserToBoardMemberDTO request)
        {
            _commandService.AddUserToBoardMember(request);
            return Ok();
        }

        [HttpPut("Parameters")]
        public ActionResult UpdateBoardmemberParameters([FromBody] UpdateBoardMemberParametersDTO request) 
        {
            _commandService.UpdateBoardMemberPatameters(request);
            return Ok(); 
        }
    }
}
