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
        //logger
        private readonly ILogger<BoardMemberController> _logger;
        public BoardMemberController(IBoardMemberCommandService boardMemberCommandService,
            IBoardMemberQuerieService boardMemberQuerieService,
            ILogger<BoardMemberController> logger)
        {
            _commandService = boardMemberCommandService;
            _querieService = boardMemberQuerieService;
            _logger = logger;
        }
        /// <summary>
        /// creates a boardmember
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostBoardMember([FromBody] CreateBoardMemberDTO request)
        {
            try
            {
                if (request != null)
                {
                    _commandService.CreateBoardMember(request);
                    return Created();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("sommething went wrong when creating a boardmember", ex.Message);
                return StatusCode(500, ex);
            }
        }
        /// <summary>
        /// reads a single boardmember from id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBoardMemberAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty) return BadRequest();

                var result = await _querieService.ReadBoardMemberAsync(id);

                if (result == null) return StatusCode(500);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("sommething went wrong when reading a boardmember", ex.Message);
                return StatusCode(500, ex);
            }
        }

        /// <summary>
        /// reads all boardmembers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetAllBoardMembersAsync()
        {
            try
            {
                var result = await _querieService.ReadAllBoardMembersAsync();

                if (result == null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("sommething went wrong when reading all boardmembers", ex.Message);
                return StatusCode(500, ex);
            }

        }
        /// <summary>
        /// updates a boardmember
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut()]
        public ActionResult PutBoardMember([FromBody]BoardMemberDTO request)
        {
            
            try
            {
                if (request != null)
                {
                    _commandService.UpdateBoardMember(request);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError("sommething went wrong when updating a boardmember", ex.Message);
                return StatusCode(500, ex);
            }

        }
        /// <summary>
        /// deletes a boardmember
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{rowVersion}")]
        public ActionResult DeleteBoardMember(Guid id, string rowVersion)
        {
            
            try
            {
                if (id == Guid.Empty || rowVersion == null) return BadRequest();
                _commandService.DeleteBoardMember(id, Convert.FromBase64String(rowVersion));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("sommething went wrong when deleting a boardmember", ex.Message);
                return StatusCode(500, ex);
            }
        }
    }
}
