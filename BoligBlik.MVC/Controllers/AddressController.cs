using AutoMapper;
using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.Models.Addresses;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace BoligBlik.MVC.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressProxy _addressProxy;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressController> _logger;

        public AddressController(IMapper mapper, IAddressProxy addressProxy)
        {

            _mapper = mapper;
            _addressProxy = addressProxy;
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

            return View(address);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Street,HouseNumber,Floor, DoorNumber,City,PostalCodeNumber, RowVersion")] UpdateAddressViewModel address)
        {


            try
            {
                var dto = _mapper.Map<UpdateAddressDTO>(address);
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

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _addressProxy.GetAddressAsync(id);
            var response = _mapper.Map<AddressViewModel>(address);
            if (address == null)
            {
                return NotFound();
            }

            return View(response);
        }

        public async Task<ActionResult> Delete(AddressViewModel deleteAddressViewModel)
        {
            var response = _mapper.Map<AddressDTO>(deleteAddressViewModel);
            var address = await _addressProxy.DeleteAddressAsync(response);

            return RedirectToAction(nameof(GetAllAddress));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var address = await _addressProxy.GetAddressAsync(id);

            return RedirectToAction(nameof(GetAllAddress));
        }



   
        //private bool AddressExists(Guid id)
        //{
        //   // return _VoresDbcontext.Addresses.Any(e => e.Id == id);
        //}
    }
}
