using AutoMapper;
using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.Models.Addresses;
using BoligBlik.MVC.Models.BookingItems;
using BoligBlik.MVC.Models.Bookings;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;
using BoligBlik.MVC.ProxyServices.BookingItems.Interfaces;
using BoligBlik.MVC.ProxyServices.Bookings.Interfaces;
using BoligBlik.MVC.ProxyServices.Users.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.MVC.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        //Dependencies - Proxy
        private readonly IBookingItemsProxy _bookingItemsProxy;
        private readonly IBookingProxy _bookingProxy;
        private readonly IUserProxy _userProxy;
        private readonly IAddressProxy _addressProxy;

        //Support
        private readonly IMapper _mapper;
        private readonly ILogger<BookingController> _logger;

        /// <summary>
        /// Controller
        /// </summary>
        public BookingController(
            IBookingItemsProxy bookingItemsProxy,
            IBookingProxy bookingProxy,
            IAddressProxy addressProxy,
            IUserProxy userProxy,
            IMapper mapper, ILogger<BookingController> logger)
        {
            _bookingItemsProxy = bookingItemsProxy;
            _bookingProxy = bookingProxy;
            _userProxy = userProxy;
            _addressProxy = addressProxy;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Read All items
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> NewBookingIndex()
        {
            try
            {
                var bookingItems = await _bookingItemsProxy.GetAllBookingItems();
                var userViewModel = _mapper.Map<IEnumerable<BookingItemViewModel>>(bookingItems);
                return View(userViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while reading all item", ex.Message);
                return NotFound();
            }

        }

        /// <summary>
        /// Read on item - select a booking of an item
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> StartBooking(Guid itemId)
        {
            try
            {
                var bookingItemViewModel = await _bookingItemsProxy.GetBookingItem(itemId);

                var allAddress = await _addressProxy.GetAllAddressAsync();

                var user = await _userProxy.GetUserAsync(User.Identity.Name);

                var userAddressDTO = allAddress.FirstOrDefault(u => u.Users.Any(a => a.Id == user.Id));


                CreateBookingViewModel bookingViewModel = new CreateBookingViewModel
                {
                    Item = _mapper.Map<BookingItemViewModel>(bookingItemViewModel),
                    AddressId = userAddressDTO.Id
                };

                return View(bookingViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while starting a booking of an item", ex.Message);
                return NotFound();
            }

        }

        /// <summary>
        /// Create a booking
        /// </summary>
        /// <param name="bookingViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingViewModel bookingViewModel)
        {
            var user = await _userProxy.GetUserAsync(User.Identity.Name);

            var allAddress = await _addressProxy.GetAllAddressAsync();

            var userAddress = allAddress.FirstOrDefault(u => u.Users.Any(a => a.Id == user.Id));

            var userAdressDTO = _mapper.Map<AddressViewModel>(userAddress);


            try
            {
                var createBookingDTO = _mapper.Map<CreateBookingDTO>(bookingViewModel);

                await _bookingProxy.CreateBooking(createBookingDTO);

                return RedirectToAction("NewBookingIndex");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while creating the booking", ex.Message);
                return View(bookingViewModel);
            }
        }

        /// <summary>
        /// Read a booking
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var bookingDTO = await _bookingProxy.GetBooking(id);
                if (bookingDTO == null)
                {
                    return NotFound();
                }

                var bookingViewModel = _mapper.Map<BookingViewModel>(bookingDTO);
                return View(bookingViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while update a booking", ex.Message);
                return NotFound();
            }

        }

        /// <summary>
        /// Update a booking
        /// </summary>
        /// <param name="bookingViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(BookingViewModel bookingViewModel)
        {
            try
            {
                var bookingDTO = _mapper.Map<BookingDTO>(bookingViewModel);
                await _bookingProxy.UpdateBookingAsync(bookingDTO);
                return RedirectToAction("GetUserBookings");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while updating the booking:", ex.Message);
                return View(bookingViewModel);
            }
        }

        /// <summary>
        /// Delete a booking
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rowVersion"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id, string rowVersion)
        {
            try
            {
                await _bookingProxy.DeleteBooking(id, rowVersion);
                return RedirectToAction("GetUserBookings");
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while deleting the booking:", ex.Message);
            }
            return RedirectToAction("GetUserBookings");
        }

        /// <summary>
        /// Read All booking on an user address
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserBookings()
        {
            try
            {
                var user = await _userProxy.GetUserAsync(User.Identity.Name);

                var allAddress = await _addressProxy.GetAllAddressAsync();

                var userAddress = allAddress.FirstOrDefault(u => u.Users.Any(a => a.Id == user.Id));
                if (userAddress is null)
                {
                    return NotFound();
                }
                var BookingVieModel = _mapper.Map<IEnumerable<BookingViewModel>>(userAddress.Bookings);

                return View(BookingVieModel);
            }
            catch (Exception ex)
            {
                _logger.LogError( "An error occurred while getting all bookings.", ex.Message);
                return View("Error");
            }

        }

        /// <summary>
        /// Read All bookins made
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            try
            {
                IEnumerable<BookingDTO> allBookings = await _bookingProxy.GetAllBookingsAsync();

                var allBookingsViewModel = _mapper.Map<IEnumerable<BookingViewModel>>(allBookings);

                return View(allBookingsViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while getting all bookings.", ex.Message);
                return View("Error");
            }
        }

    }
}
