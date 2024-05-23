using AutoMapper;
using BoligBlik.MVC.DTO.Bookings;
using BoligBlik.MVC.Models.BookingItems;
using BoligBlik.MVC.Models.Bookings;
using BoligBlik.MVC.Models.Users;
using BoligBlik.MVC.ProxyServices.BookingItems.Interfaces;
using BoligBlik.MVC.ProxyServices.Bookings.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.MVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingItemsProxy _bookingItemsProxy;
        private readonly IBookingProxy _bookingProxy;
        private readonly IMapper _mapper;

        public BookingController(IBookingItemsProxy bookingItemsProxy, IBookingProxy bookingProxy, IMapper mapper)
        {
            _bookingItemsProxy = bookingItemsProxy;
            _bookingProxy = bookingProxy;
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
            var bookingItem = await _bookingItemsProxy.GetBookingItem(itemId);
            var bookingViewModel = new CreateBookingViewModel
            {
                ItemId = bookingItem.Id
            };
            return View(bookingViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingViewModel bookingViewModel)
        {
            if (ModelState.IsValid)
            {
                var createBookingDTO = _mapper.Map<CreateBookingDTO>(bookingViewModel);

                await _bookingProxy.CreateBooking(createBookingDTO);

                return RedirectToAction("NewBookingIndex");
            }
            else
            {
                return View(bookingViewModel);
            }
        }












        //[HttpGet]
        //public async Task<IActionResult> StartBooking(Guid itemId)
        //{
        //    var bookingItem = await _bookingItemsProxy.GetBookingItem(itemId);
        //    var bookingViewModel = _mapper.Map<CreateBookingViewModel>(bookingItem);
        //    return View(bookingViewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> StartBooking(BookingViewModel bookingViewModel)
        //{
        //    var createBookingDTO = _mapper.Map<CreateBookingDTO>(bookingViewModel);

        //    await _bookingProxy.CreateBooking(createBookingDTO);

        //    return RedirectToAction("NewBookingIndex");
        //}


        //public IActionResult YoursBookings()
        //{
        //    return View();
        //}
    }
}
