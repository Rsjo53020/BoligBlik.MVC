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
                var userDTO = await _userProxy.GetUserAsync(boardMemberViewModel.User.EmailAddress);
                var boardMemberDTO = _mapper.Map<BoardMemberDTO>(boardMemberViewModel);
                boardMemberDTO.User = userDTO;
                var result = await _boardMemberProxy.UpdateBoardMemberAsync(boardMemberDTO);


                var identityUser = await _userManager.FindByEmailAsync(boardMemberDTO.User.EmailAddress);
                if (boardMemberDTO.Title == "Formand" || boardMemberDTO.Title == "Admin")
                {
                    var existingAdminClaims = await _userManager.GetClaimsAsync(identityUser);

                    foreach (var claim in existingAdminClaims.Where(c => c.Type != "Admin" || c.Type == "Admin"))
                    {
                        await _userManager.RemoveClaimAsync(identityUser, claim);
                    }
                    var claimToUser = new Claim("Admin", boardMemberDTO.Title);
                    await _userManager.AddClaimAsync(identityUser, claimToUser);
                }

                if (boardMemberDTO.Title == "Næstformand" || boardMemberDTO.Title == "Kasserer" ||
                    boardMemberDTO.Title == "Bestyrelse")
                {
                    var existingAdminClaims = await _userManager.GetClaimsAsync(identityUser);
                    foreach (var claim in existingAdminClaims.Where(c => c.Type != "Boardmembers" || c.Type == "Boardmembers"))
                    {
                        await _userManager.RemoveClaimAsync(identityUser, claim);
                    }
                    var claimToUser = new Claim("Boardmembers", boardMemberDTO.Title);
                    await _userManager.AddClaimAsync(identityUser, claimToUser);
                }

                //var addClaimToBoardMember = AddClaimToBoardMember(boardMemberDTO);

                return RedirectToAction("ReadAll", "BoardMember");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while updating a boardMember", ex);
                return NotFound();
            }

        }

        private async Task<bool> AddClaimToBoardMember(BoardMemberDTO boardMemberDTO)
        {

            if (boardMemberDTO.Title == "Formand" || boardMemberDTO.Title == "Admin")
            {

                var identityUser = await _userManager.FindByEmailAsync(boardMemberDTO.User.EmailAddress);
                var existingAdminClaims = await _userManager.GetClaimsAsync(identityUser);

                foreach (var claim in existingAdminClaims.Where(c => c.Type != "Admin"))
                {
                    await _userManager.RemoveClaimAsync(identityUser, claim);
                }
                var claimToUser = new Claim("Admin", boardMemberDTO.Title);
                await _userManager.AddClaimAsync(identityUser, claimToUser);
            }

            if (boardMemberDTO.Title == "Næstformand" || boardMemberDTO.Title == "Kassérer" || boardMemberDTO.Title == "Bestyrelse")
            {
                var identityUser = await _userManager.FindByEmailAsync(boardMemberDTO.User.EmailAddress);
                var existingAdminClaims = await _userManager.GetClaimsAsync(identityUser);

                foreach (var claim in existingAdminClaims.Where(c => c.Type != "Boardmembers"))
                {
                    await _userManager.RemoveClaimAsync(identityUser, claim);
                }

                var claimToUser = new Claim("Boardmembers", boardMemberDTO.Title);
                await _userManager.AddClaimAsync(identityUser, claimToUser);
            }

            return true;
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
