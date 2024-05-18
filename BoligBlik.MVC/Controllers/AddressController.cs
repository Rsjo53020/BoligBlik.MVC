using AutoMapper;
using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.Models.Addresses;
using BoligBlik.MVC.Models.BoardMembers;
using BoligBlik.MVC.ProxyServices.Addresses.Interfaces;
using BoligBlik.MVC.ProxyServices.BoardMembers;
using BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace BoligBlik.MVC.Controllers
{
    public class AddressController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IAddressProxy _addressProxy;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressController> _logger;

        public AddressController(IHttpClientFactory httpClientFactory, IMapper mapper, IAddressProxy addressProxy)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
            _addressProxy = addressProxy;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            try
            {
                var resoponse = await _addressProxy.GetAllAddressAsync();
                var addressesList = new List<AddressViewModel>();
                foreach (var addressDTO in resoponse)
                {
                    addressesList.Add(_mapper.Map<AddressViewModel>(addressDTO));
                }
                return View(addressesList);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while reading all addresses", ex);

                return View(new List<AddressViewModel>());
            }
        }

        // GET: AddressController/Create
        public async Task<IActionResult> Create(CreateAddressViewModel createAddressViewModel)
        {
            var createAddressDto = _mapper.Map<CreateAddressDTO>(createAddressViewModel);
            var response = await _addressProxy.CreateAddressAsync(createAddressDto);

            return View();
        }



        // GET: AddressController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AddressController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetAllAddress));
            }
            catch
            {
                return View();
            }
        }

        // GET: AddressController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AddressController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(GetAllAddress));
            }
            catch
            {
                return View();
            }
        }
    }
}
