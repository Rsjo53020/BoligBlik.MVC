using BoligBlik.Application.Interfaces.Addresses.Queries;
using BoligBlik.Application.Interfaces.Repositories;
using AutoMapper;
using BoligBlik.Application.Common.Exceptions;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Entities;
using System.Net;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Application.Features.Addresses.Queries
{
    public class AddressQuerieService : IAddressQuerieService
    {
        //Dependencies 
        private readonly IAddressQuerieRepo _addressRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<AddressQuerieService> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="addressRepo"></param>
        /// <param name="mapper"></param>
        public AddressQuerieService(IAddressQuerieRepo addressRepo, IMapper mapper, ILogger<AddressQuerieService> logger)
        {
            _addressRepo = addressRepo;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Read all addresses asynchronously  
        /// </summary>
        /// <returns></returns>
        /// <exception cref="AddressesNotFoundException"></exception>
        public async Task<IEnumerable<AddressDTO>> ReadAllAsync()
        {
            try
            {
                var addresses = await _addressRepo.ReadAllAsync();
                
                var dtoList = _mapper.Map<IEnumerable<AddressDTO>>(addresses);

                return dtoList;
            }
            catch (Exception ex)
            {
                throw new AddressesNotFoundException($"Addresses was not found: {ex.Message}");
            }
        }

        /// <summary>
        /// Read Address asynchronously by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AddressDTO> ReadAddressAsync(Guid id)
        {
            var response = await _addressRepo.ReadAddress(id);
            var addressMap = _mapper.Map<AddressDTO>(response);
            return addressMap;
            //throw new AddressNotFoundException(response.Id);
            
        }
    }
}
