using AutoMapper;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.BoardMembers;
using BoligBlik.MVC.Models.Users;
using BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace BoligBlik.MVC.Controllers
{
    public class BoardMemberController : Controller
    {
        private readonly IBoardMemberProxy _boardMemberProxy;
        private readonly IMapper _mapper;
        private readonly ILogger<BoardMemberController> _logger;
        private readonly IUserProxy _userProxy;
        private readonly UserManager<IdentityUser> _userManager;
        public BoardMemberController(IBoardMemberProxy boardMemberProxy, IMapper mapper, IUserProxy userProxy, UserManager<IdentityUser> userManager)
        {
            _boardMemberProxy = boardMemberProxy;
            _mapper = mapper;
            _userProxy = userProxy;
            _userManager = userManager;
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
                return NotFound();
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
                    var boardMember = _mapper.Map<BoardMemberViewModel>(boardMemberDTO);
                    boardMember.User = _mapper.Map<UserViewModel>(boardMemberDTO.User);
                    boardMembers.Add(boardMember);
                }
                return View(boardMembers);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while reading all boardMembers", ex);
                return NotFound();
            }
        }

        /// <summary>
        /// gets the update page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            try
            {
                var result = await _boardMemberProxy.GetBoardMemberAsync(id);

                if (result != null && result.Id == id)
                {
                    var boardMember = _mapper.Map<BoardMemberViewModel>(result);

                    boardMember.User = _mapper.Map<UserViewModel>(result.User);

                    return View(boardMember);
                }
                return View();
                
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while reading a boardMember", ex);
                return NotFound();
            }
        }


        /// <summary>
        /// Update a BoardMember async
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Update(BoardMemberViewModel boardMemberViewModel)
        {
            try
            {
                var userDTO = await _userProxy.GetUserAsync(boardMemberViewModel.User.EmailAddress);
                var boardMemberDTO = _mapper.Map<BoardMemberDTO>(boardMemberViewModel);
                boardMemberDTO.User = userDTO;
                var result = await _boardMemberProxy.UpdateBoardMemberAsync(boardMemberDTO);

                var identityUser = await _userManager.FindByEmailAsync(boardMemberDTO.User.EmailAddress);
                var claim = new Claim("Admin", boardMemberDTO.Title);
                await _userManager.AddClaimAsync(identityUser, claim);

                return RedirectToAction("ReadAll", "BoardMember");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while updating a boardMember", ex);
                return NotFound();
            }
        }

        /// <summary>
        /// Deletes a BoardMember async
        /// </summary>
        /// <param name="deleteBoardMemberViewModel"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id, string rowVersion)
        {
            try
            {
                var boardMember = await _boardMemberProxy.GetBoardMemberAsync(id);

                if (boardMember != null && boardMember.Id == id)
                {
                    var result = await _boardMemberProxy.DeleteBoardMemberAsync(boardMember.Id, rowVersion);
                }
                return RedirectToAction("ReadAll", "BoardMember");

            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while deleting a boardMember", ex);
                return NotFound();
            }
            
        }
    }
}
