using Azure.Core;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.Interfaces.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.BoardMembers.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardMemberController : ControllerBase
    {
        //services
        private readonly IBoardMemberCommandService _commandService;
        private readonly IBoardMemberQuerieService _querieService;
        public BoardMemberController(IBoardMemberCommandService boardMemberCommandService,
            IBoardMemberQuerieService boardMemberQuerieService)
        {
            _commandService = boardMemberCommandService;
            _querieService = boardMemberQuerieService;
        }
        /// <summary>
        /// creates a boardmember
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostBoardMember([FromBody] CreateBoardMemberDTO request)
        {
            if (request == null) return BadRequest();
            _commandService.CreateBoardMember(request);
            return Created();
        }
        /// <summary>
        /// reads a single boardmember from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBoardMemberAsync(Guid id)
        {
            if(id == Guid.Empty) return BadRequest();

            var result = await _querieService.ReadBoardMemberAsync(id);

            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// reads all boardmembers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllBoardMembersAsync()
        {
            var result = await _querieService.ReadAllBoardMembersAsync();

            if (result == null) return NotFound();
            return Ok(result);

        }
        /// <summary>
        /// updates a boardmember
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut()]
        public ActionResult PutBoardMember([FromBody]BoardMemberDTO request)
        {
            if (request == null) return BadRequest();
            try
            {
                _commandService.UpdateBoardMember(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        /// <summary>
        /// deletes a boardmember
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{rowVersion}")]
        public ActionResult DeleteBoardMember(Guid id, Byte[] rowVersion)
        {
            if(id == null || rowVersion == null) return BadRequest();
            try
            {
                _commandService.DeleteBoardMember(id, rowVersion);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
