using AutoMapper;
using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Addresses;
using BoligBlik.MVC.Models.BoardMembers;
using BoligBlik.MVC.Models.Users;
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


        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressViewModel createAddressViewModel)
        {
            var createAddressDto = _mapper.Map<CreateAddressDTO>(createAddressViewModel);
            var response = await _addressProxy.CreateAddressAsync(createAddressDto);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddress()
        {
            try
            {
                var resoponse = await _addressProxy.GetAllAddressAsync();
                var addressesList = _mapper.Map<IEnumerable<AddressViewModel>>(resoponse);
                return View(addressesList);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured while reading all addresses", ex);
                return View(new List<AddressViewModel>());
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAddress(AddressViewModel addressViewModel )
        //{
        //    try
        //    {
        //        var resoponse = await _addressProxy.GetAddressAsync(addressViewModel.Id);
        //        var addresses = _mapper.Map<AddressViewModel>(resoponse);
        //        return View(addresses);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("An error occured while reading all addresses", ex.Message);
        //        return View();
        //    }
        //}

        // GET: AddressController
        [HttpPut]
        public async Task<IActionResult> Edit(UpdateAddressViewModel updateAddressViewModel)
        {
            var response = _mapper.Map<UpdateAddressDTO>(updateAddressViewModel);
            var address = await _addressProxy.UpdateAddressAsync(response);

            if (address != null)
            {
                var updateUserDTO = _mapper.Map<UpdateAddressDTO>(updateAddressViewModel);
                await _addressProxy.UpdateAddressAsync(updateUserDTO);
            }

            return RedirectToAction(nameof(GetAllAddress));
        }


        // GET: AddressController/Delete
        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteAddressViewModel deleteAddressViewModel)
        {
            //var response = _mapper.Map<DeleteAddressDTO>(deleteAddressViewModel);
            //var address = await _addressProxy.DeleteAddressAsync(response);

            return RedirectToAction(nameof(GetAllAddress));
        }







        // POST: AddressController/Edit/5
        [HttpPut]
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
