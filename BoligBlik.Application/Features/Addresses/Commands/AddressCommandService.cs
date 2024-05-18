using AutoMapper;
using BoligBlik.Application.Interfaces.Addresses.Commands;
using BoligBlik.Application.Interfaces.Infrastructure;
using BoligBlik.Application.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Entities;

namespace BoligBlik.Application.Features.Addresses.Commands
{
    public class AddressCommandService : IAddressCommandService
    {
        private readonly IAddressCommandRepo _addressRepo;
        private readonly IAddressValidationInf _addressValidationInf;
        private readonly IMapper _mapper;
        public AddressCommandService(IAddressCommandRepo addressRepo, IMapper mapper, IAddressValidationInf addressValidationInf)
        {
            _addressRepo = addressRepo;
            _addressValidationInf = addressValidationInf;
            _mapper = mapper;
        }


        public void CreateAddress(CreateAddressDTO request)
        {
            var address = _mapper.Map<Address>(request);
            var resultat = _addressValidationInf.ValidateAddressAsync(address);

            if (resultat.IsFaulted)
                throw new ValidationException("Validation failed on address");

            if (resultat.IsCompletedSuccessfully)
                _addressRepo.CreateAddress(address);
        }

        public void UpdateAddress(UpdateAddressDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
