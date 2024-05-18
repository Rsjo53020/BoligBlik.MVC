using AutoMapper;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.Models.BoardMembers;
using BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.MVC.Controllers
{
    public class BoardMemberController : Controller
    {
        private readonly IBoardMemberProxy _boardMemberProxy;
        private readonly IMapper _mapper;
        private readonly ILogger<BoardMemberController> _logger;
        public BoardMemberController(IBoardMemberProxy boardMemberProxy, IMapper mapper)
        {
            _boardMemberProxy = boardMemberProxy;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Creates a BoardMember async 
        /// </summary>
        /// <param name="createBoardMemberViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateBoardMemberViewModel createBoardMemberViewModel)
        {
            try
            {
                var createBoardMemberDTO = _mapper.Map<CreateBoardMemberDTO>(createBoardMemberViewModel);
                var result = await _boardMemberProxy.CreateBoardMemberAsync(createBoardMemberDTO);
                return RedirectToAction("ReadAll", "BoardMember");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while creating a boardMember", ex);
                return RedirectToAction("ReadAll", "BoardMember");
            }
        }

        /// <summary>
        /// Reads all BoardMembers async
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            try
            {
                var result = await _boardMemberProxy.GetAllBoardMembersAsync();
                var boardMembers = new List<BoardMemberViewModel>();
                foreach (var boardMemberDTO in result)
                {
                    boardMembers.Add(_mapper.Map<BoardMemberViewModel>(boardMemberDTO));
                }
                return View(boardMembers);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while reading all boardMembers", ex);
                return View(new List<BoardMemberViewModel>());
            }
        }

        /// <summary>
        /// Reads a boardMember from title
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Read(string title)
        {
            try
            {
                var result = await _boardMemberProxy.GetBoardMemberAsync(title);

                var boardMember = _mapper.Map<BoardMemberViewModel>(result);

                return View(boardMember);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while reading a boardMember", ex);
                return View(new BoardMemberViewModel());
            }
        }

        /// <summary>
        /// Update a BoardMember async
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(BoardMemberViewModel boardMemberViewModel)
        {
            try
            {
                var boardMemberDTO = _mapper.Map<BoardMemberDTO>(boardMemberViewModel);
                //var result = await _boardMemberProxy.UpdateBoardMemberAsync(updateBoardMemberDTO);
                return View(/*result*/);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while updating a boardMember", ex);
                return View(false);
            }
        }

        /// <summary>
        /// Deletes a BoardMember async
        /// </summary>
        /// <param name="deleteBoardMemberViewModel"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _boardMemberProxy.DeleteBoardMemberAsync(id);
                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while deletign a boardMember", ex);
                return View(false);
            }
        }
    }
}
