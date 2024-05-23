using AutoMapper;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Users;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserProxy _userProxy;
        private readonly IMapper _mapper;

        public UserController(IUserProxy userProxy, IMapper mapper)
        {
            _userProxy = userProxy;
            _mapper = mapper;
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

            if (user != null)
            {
                var updateUserDTO = _mapper.Map<UserDTO>(updateUserViewModel);
                await _userProxy.UpdateUserAsync(updateUserDTO);
            }

            return RedirectToAction("GetAll");
        }
    }
}
