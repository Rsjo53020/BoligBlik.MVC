using AutoMapper;
using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.Interfaces.Addresses.Commands;
using BoligBlik.Application.Interfaces.Infrastructure;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Value;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        

        public void Create(AddressDTO request)
        {
            var address = _mapper.Map<Address>(request);
            var resultat = _addressValidationInf.ValidateAddressAsync(address);

            if (resultat != Task.CompletedTask)
                throw new ValidationException("Validation failed on address");
            if (resultat == Task.CompletedTask)
            {
                _addressRepo.Create(address);
            }

        }

        //public void Create(AddressDTO request)
        //{
        //    var address = _mapper.Map<Address>(request);
        //    var resultat = _addressValidationInf.ValidateAddressesAsync(address);

        //    if (resultat != Task.CompletedTask) 
        //        throw new ValidationException("Validation failed on address");
        //    if (resultat == Task.CompletedTask)
        //    {
        //       _addressRepo.Create(address);
        //    }

        //}
    }
}
