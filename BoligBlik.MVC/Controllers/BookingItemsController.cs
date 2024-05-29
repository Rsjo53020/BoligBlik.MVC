using AutoMapper;
using BoligBlik.MVC.DTO.BookingItems;
using BoligBlik.MVC.Models.BookingItems;
using BoligBlik.MVC.ProxyServices.BookingItems.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoligBlik.MVC.Controllers
{
    public class BookingItemsController : Controller
    {
        private readonly IBookingItemsProxy _bookingItemsProxy;
        private readonly ILogger<BookingItemsController> _logger;
        private readonly IMapper _mapper;

        public BookingItemsController(IBookingItemsProxy bookingItemsProxy, ILogger<BookingItemsController> logger, IMapper mapper = null)
        {
            _bookingItemsProxy = bookingItemsProxy;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: BookingItemsController
        public async Task<ActionResult> List()
        {
            try
            {
                var bookingItemDTOs = await _bookingItemsProxy.GetAllBookingItems();
                var bookingItemViewModels = _mapper.Map<IEnumerable<BookingItemViewModel>>(bookingItemDTOs);
                return View(bookingItemViewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError("something went wrong when getting all booking items", ex);
                return NotFound();
            }
        }

        [HttpGet]
        // GET: BookingItemsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingItemsController/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateBookingItemViewModel createBookingItemViewModel)
        {
            try
            {
                var createBookingItemDTO = _mapper.Map<CreateBookingItemDTO>(createBookingItemViewModel);
                await _bookingItemsProxy.CreateBookingItem(createBookingItemDTO);
                return RedirectToAction("List", "BookingItems");
            }
            catch(Exception ex)
            {
                _logger.LogError("something went wrong when creating a booking item", ex);
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                var bookingItemDTO = await _bookingItemsProxy.GetBookingItem(id);
                var bookingItemViewModel = _mapper.Map<BookingItemViewModel>(bookingItemDTO);
                return View(bookingItemViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("something went wrong when deleting a booking item", ex);
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(BookingItemViewModel bookingItemViewModel)
        {
            try
            {
                var bookingItemDTO = _mapper.Map<BookingItemDTO>(bookingItemViewModel);
                await _bookingItemsProxy.UpdateBookingItem(bookingItemDTO);
                return RedirectToAction("List", "BookingItems");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookingItemsController/Delete/5

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id, string rowVersion)
        {
            try
            {
                await _bookingItemsProxy.DeleteBookingItem(id, rowVersion);
                return RedirectToAction("List", "BookingItems");
            }
            catch (Exception ex)
            {
                _logger.LogError("something went wrong when deleting a booking item", ex);
                return NotFound();
            }
        }

       
    }
}
