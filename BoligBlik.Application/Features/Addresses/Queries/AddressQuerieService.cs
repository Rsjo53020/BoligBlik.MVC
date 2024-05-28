using BoligBlik.Application.Interfaces.Addresses.Queries;
using BoligBlik.Application.Interfaces.Repositories;
using AutoMapper;
using BoligBlik.Application.Common.Exceptions;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Entities;
using System.Net;

namespace BoligBlik.Application.Features.Addresses.Queries
{
    public class AddressQuerieService : IAddressQuerieService
    {
        private readonly IAddressQuerieRepo _addressRepo;
        private readonly IMapper _mapper;
        public AddressQuerieService(IAddressQuerieRepo addressRepo, IMapper mapper)
        {
            _addressRepo = addressRepo;
            _mapper = mapper;
        }


        public async Task<IEnumerable<AddressDTO>> ReadAllAsync()
        {
            try
            {
                //var bookingItems = await _bookingItemsRepo.ReadAllBookingItemsAsync();
                //return _mapper.Map<IEnumerable<BookingItemDTO>>(bookingItems);

                var addresses = await _addressRepo.ReadAllAsync();
                
                var dtoList = _mapper.Map<IEnumerable<AddressDTO>>(addresses);

                //List<AddressDTO> addressList = new List<AddressDTO>();

                //foreach (var address in addresses)
                //{
                //    var dto = _mapper.Map<AddressDTO>(address);
                //    addressList.Add(dto);
                //}

                return dtoList;
            }
            catch (Exception ex)
            {
                throw new AddressesNotFoundException($"Addresses was not found: {ex.Message}");
            }
        }

        public async Task<AddressDTO> ReadAddress(Guid id)
        {
            var response = await _addressRepo.ReadAddress(id);
            var addressMap = _mapper.Map<AddressDTO>(response);
            return addressMap;
            //throw new AddressNotFoundException(response.Id);
            
        }
    }
}
