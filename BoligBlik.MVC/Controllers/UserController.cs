using AutoMapper;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Users;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BoligBlik.MVC.Models.BoardMembers;

namespace BoligBlik.MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //identity user services
        private readonly UserManager<IdentityUser> _userManager;
        //proxy
        private readonly IUserProxy _userProxy;
        //mapper
        private readonly IMapper _mapper;
        //logger
        private readonly ILogger<UserController> _logger;

        public UserController(IUserProxy userProxy, IMapper mapper, UserManager<IdentityUser> userManager, ILogger<UserController> logger)
        {
            _userProxy = userProxy;
            _mapper = mapper;
            _userManager = userManager;
            _logger = logger;
        }
        /// <summary>
        /// Read all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userProxy.GetAllUsersAsync();
                var userViewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);
                return View(userViewModel);

            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while reading all users", ex.Message);
                return View(new List<UserViewModel>());
            }

        }

        /// <summary>
        /// Read one user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(string email)
        {
            try
            {
                var user = await _userProxy.GetUserAsync(email);
                var updateUserViewModel = _mapper.Map<UserViewModel>(user);
                return View(updateUserViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while reading an user", ex.Message);
                return View(new UserViewModel());
            }

        }

        /// <summary>
        /// Update an user
        /// </summary>
        /// <param name="updateUserViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel updateUserViewModel)
        {
            try
            {
                var user = await _userProxy.GetUserAsync(updateUserViewModel.EmailAddress);

                if (user.Id == updateUserViewModel.Id)
                {
                    var updateUserDTO = _mapper.Map<UserDTO>(updateUserViewModel);
                    await _userProxy.UpdateUserAsync(updateUserDTO);
                }

                return RedirectToAction("GetAll");

            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while update an user", ex.Message);
                return RedirectToAction("GetAll");
            }

        }
        
        /// <summary>
        /// Delete an user in frontend and backend
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id, string email, string rowVersion)
        {
            try
            {
                //find login 
                var identityUser = _userManager.Users.FirstOrDefault(x => x.Email == email);
                //backend

                await _userProxy.DeleteUserAsync(id, rowVersion);

                //delete login
                _userManager.DeleteAsync(identityUser);

                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while deleting an user", ex.Message);
                return RedirectToAction("GetAll");
            }
        }
    }
}
