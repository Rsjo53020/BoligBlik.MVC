﻿using AutoMapper;
using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.Models.Addresses;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using BoligBlik.MVC.Models.Users;
using BoligBlik.MVC.DTO.User;


namespace BoligBlik.MVC.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressProxy _addressProxy;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressController> _logger;
        private readonly IUserProxy _userProxy;

        public AddressController(IMapper mapper, IAddressProxy addressProxy, IUserProxy userProxy, ILogger<AddressController> logger)
        {

            _mapper = mapper;
            _addressProxy = addressProxy;
            _userProxy = userProxy;
            _logger = logger;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Street,HouseNumber,Floor, DoorNumber,City,PostalCodeNumber")] CreateAddressViewModel address)
        {
            try
            {
                var dto = _mapper.Map<CreateAddressDTO>(address);
                var response = await _addressProxy.CreateAddressAsync(dto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("An error occured while create a address", ex.Message);
                _logger.LogError($"An error occured while reading all addresses: {ex.Message}");

                return RedirectToAction(nameof(GetAllAddress));
            }

            return new RedirectResult(nameof(GetAllAddress));// RedirectToAction(nameof(GetAllAddress)); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            try
            {
                var response = await _addressProxy.GetAllAddressAsync();
                var addressesList = _mapper.Map<IEnumerable<AddressViewModel>>(response);
                return View(addressesList);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while reading all addresses", ex);
                return View(new List<AddressViewModel>());
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null) return NotFound();

            var response = await _addressProxy.GetAddressAsync(id);
            var address = _mapper.Map<AddressViewModel>(response);
            if (address == null)
            {
                return NotFound();
            }

            var userDTOs = await _userProxy.GetUsersWithoutAddressAsync();
            var usersVithoutAddresses = _mapper.Map<IEnumerable<UserViewModel>>(userDTOs);
            var editAddress = new AddressEditViewModel();
            editAddress.Address = address;
            editAddress.UsersWithoutAddress = usersVithoutAddresses;
            return View(editAddress);
        }

        [HttpPost]
        public async Task<IActionResult> Details(AddressEditViewModel addressEditViewModel)
        {
            try
            {
                var userDTO = await _userProxy.GetUserAsync(addressEditViewModel.selectedUser.EmailAddress);

                List<UserDTO> users = new();
                users.Add(userDTO);


                var addressDTO = _mapper.Map<AddressDTO>(addressEditViewModel.Address);

                addressDTO.Users = users;

                await _addressProxy.UpdateAddressAsync(addressDTO);

                return RedirectToAction(nameof(GetAllAddress));

            }
            catch (Exception ex)
            {
                _logger.LogError("something went wront when adding a user to an address", ex.Message);
                return NotFound();
            }

        }

        public async Task<IActionResult> Edit(Guid id)
        {
            if (id == Guid.Empty) return NotFound();

            var address = await _addressProxy.GetAddressAsync(id);
            if (address == null) return NotFound();

            var response = _mapper.Map<AddressViewModel>(address);
            return View(response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AddressViewModel addressViewModel)
        {


            try
            {

                var dto = _mapper.Map<AddressDTO>(addressViewModel);
                var response = await _addressProxy.UpdateAddressAsync(dto);
                return RedirectToAction(nameof(GetAllAddress));

            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!AddressExists(address.Id)) return NotFound();
                _logger.LogError("An error occurred while updating an address");
                ModelState.AddModelError(string.Empty, "Unable to save changes. The address was updated by another user.");
            }
            return RedirectToAction(nameof(GetAllAddress));


        }




    }
}
