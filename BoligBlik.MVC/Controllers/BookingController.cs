﻿using AutoMapper;
using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.Models.Addresses;
using BoligBlik.MVC.Models.BookingItems;
using BoligBlik.MVC.Models.Bookings;
using BoligBlik.MVC.Models.Users;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;
using BoligBlik.MVC.ProxyServices.BookingItems.Interfaces;
using BoligBlik.MVC.ProxyServices.Bookings.Interfaces;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BoligBlik.MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingItemsProxy _bookingItemsProxy;
        private readonly IBookingProxy _bookingProxy;
        private readonly IUserProxy _UserProxy;
        private readonly IAddressProxy _addressProxy;
        private readonly IMapper _mapper;

        public BookingController(IBookingItemsProxy bookingItemsProxy, IBookingProxy bookingProxy, IAddressProxy addressProxy, IUserProxy userProxy,
            IMapper mapper)
        {
            _bookingItemsProxy = bookingItemsProxy;
            _bookingProxy = bookingProxy;
            _UserProxy = userProxy;
            _addressProxy = addressProxy;
            _mapper = mapper;
        }

        public async Task<IActionResult> NewBookingIndex()
        {
            var bookingItems = await _bookingItemsProxy.GetAllBookingItems();
            var userViewModel = _mapper.Map<IEnumerable<BookingItemViewModel>>(bookingItems);
            return View(userViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> StartBooking(Guid itemId)
        {
            var bookingItemViewModel = await _bookingItemsProxy.GetBookingItem(itemId);

            CreateBookingViewModel bookingViewModel = new CreateBookingViewModel
            {
                BookingItem = _mapper.Map<BookingItemViewModel>(bookingItemViewModel)
            };

            return View(bookingViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingViewModel bookingViewModel)
        {
            var user = await _UserProxy.GetUserAsync(User.Identity.Name);

            var allAddress = await _addressProxy.GetAllAddressAsync();

            var userAddress = allAddress.FirstOrDefault(u => u.Users.Any(a => a.Id == user.Id));

            var userAdressDTO = _mapper.Map<AddressViewModel>(userAddress);
            bookingViewModel.Address = userAdressDTO;

            try
            {
                var createBookingDTO = _mapper.Map<CreateBookingDTO>(bookingViewModel);

                await _bookingProxy.CreateBooking(createBookingDTO);

                return RedirectToAction("NewBookingIndex");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred while creating the booking: {ex.Message}");
                return View(bookingViewModel);
            }
        }
    }
}
