using AutoMapper;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.Models.BoardMembers;
using BoligBlik.MVC.Models.Users;
using BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BoligBlik.MVC.Controllers
{
    public class BoardMemberController : Controller
    {
        //SUPPORT
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger<BoardMemberController> _logger;

        //Proxy
        private readonly IUserProxy _userProxy;
        private readonly IBoardMemberProxy _boardMemberProxy;
        public BoardMemberController(IBoardMemberProxy boardMemberProxy, IMapper mapper, IUserProxy userProxy, UserManager<IdentityUser> userManager, ILogger<BoardMemberController> logger)
        {
            _boardMemberProxy = boardMemberProxy;
            _mapper = mapper;
            _userProxy = userProxy;
            _userManager = userManager;
            _logger = logger;
        }
        
        /// <summary>
        /// Create view for BoardMember
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Create a BoardMember
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
        [AllowAnonymous]
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
                return View(new List<BoardMemberViewModel>());
            }
        }

        /// <summary>
        /// Update view for a BoardMember
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
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
        /// Update a BoardMember and add a claim with the boardmember title
        /// </summary>
        /// <param name="boardMemberViewModel"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(BoardMemberViewModel boardMemberViewModel)
        {
            try
            {
                //get user from email
                var userDTO = await _userProxy.GetUserAsync(boardMemberViewModel.User.EmailAddress);
                var boardMemberDTO = _mapper.Map<BoardMemberDTO>(boardMemberViewModel);
                boardMemberDTO.User = userDTO;
                //update in backend
                var result = await _boardMemberProxy.UpdateBoardMemberAsync(boardMemberDTO);

                //get identity user
                var identityUser = await _userManager.FindByEmailAsync(boardMemberDTO.User.EmailAddress);
                //if formand/ admin 
                if (boardMemberDTO.Title == "Formand" || boardMemberDTO.Title == "Admin")
                {
                    await SetNewClaim(identityUser, "Admin", boardMemberDTO.Title);
                }
                //everybody else
                else 
                {
                    await SetNewClaim(identityUser, "Boardmembers", boardMemberDTO.Title);
                }

                return RedirectToAction("ReadAll", "BoardMember");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while updating a boardMember", ex);
                return NotFound();
            }
            

        }

        private async Task SetNewClaim(IdentityUser identityUser, string claimType, string title)
        {
            //find claims for identity user
            var existingAdminClaims = await _userManager.GetClaimsAsync(identityUser);

            //remove existing claims
            foreach (var claim in existingAdminClaims.Where(c => c.Type != claimType || c.Type == claimType))
            {
                await _userManager.RemoveClaimAsync(identityUser, claim);
            }

            //add new claim
            var claimToUser = new Claim(claimType, title);
            await _userManager.AddClaimAsync(identityUser, claimToUser);
        }

        /// <summary>
        /// Delete a BoardMember
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
        [Authorize]
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
