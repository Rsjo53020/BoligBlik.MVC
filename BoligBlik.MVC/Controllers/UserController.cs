using AutoMapper;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Users;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserProxy _userProxy;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserProxy userProxy, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _userProxy = userProxy;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userProxy.GetAllUsersAsync();
            var userViewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);
            return View(userViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string email)
        {
            var user = await _userProxy.GetUserAsync(email);
            var updateUserViewModel = _mapper.Map<UserViewModel>(user);
            return View(updateUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel updateUserViewModel)
        {
            var user = await _userProxy.GetUserAsync(updateUserViewModel.EmailAddress);

            if (user.Id == updateUserViewModel.Id)
            {
                var updateUserDTO = _mapper.Map<UserDTO>(updateUserViewModel);
                await _userProxy.UpdateUserAsync(updateUserDTO);
            }

            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var userDTO = await _userProxy.GetUserAsync(id);
                var identityUser = _userManager.Users.FirstOrDefault(x => x.Email == userDTO.EmailAddress);
                _userManager.DeleteAsync(identityUser);
                await _userProxy.DeleteUserAsync(id);
                
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while deleting a user", ex.Message);
                return RedirectToAction("GetAll");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Claims(string email)
        {
            var user = await _userProxy.GetUserAsync(email);
            var updateUserViewModel = _mapper.Map<UserViewModel>(user);
            return View(updateUserViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Claims(UserViewModel userViewModel)
        {
            try
            {
                return RedirectToAction("GetAll");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while updating claims of a user", ex.Message);
                return RedirectToAction("GetAll");
            }
        }

    }
}
