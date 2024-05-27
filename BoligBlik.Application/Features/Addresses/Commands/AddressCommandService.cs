using AutoMapper;
using BoligBlik.Application.Interfaces.Addresses.Commands;
using BoligBlik.Application.Interfaces.Infrastructure;
using BoligBlik.Application.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Data;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Entities;
using BoligBlik.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Application.Features.Addresses.Commands
{
    public class AddressCommandService : IAddressCommandService
    {
        //Repositories
        private readonly IAddressCommandRepo _addressRepo;
        //Validate address API.DAWA
        private readonly IAddressValidationInf _addressValidationInf;
        //Mappers
        private readonly IMapper _mapper;
        //UnitOfWork
        private readonly IUnitOfWork _unitOfWork;
        //Logger
        private readonly ILogger<IAddressCommandService> _logger;

        public AddressCommandService(IAddressCommandRepo addressRepo, IMapper mapper, IAddressValidationInf addressValidationInf, IUnitOfWork unitOfWork, ILogger<IAddressCommandService> logger)
        {
            _addressRepo = addressRepo;
            _addressValidationInf = addressValidationInf;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Create an address
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="ValidationException"></exception>
        public void CreateAddress(CreateAddressDTO request)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                var address = _mapper.Map<Address>(request);


                var resultat = _addressValidationInf.ValidateAddressAsync(address);
               
                    _addressRepo.CreateAddress(address);
                    _unitOfWork.Commit();
                
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError("Error create address with request: {@request}, Exception: {ex}", request, ex);
                throw new ValidationException("Validation failed on address");
            }
        }

        public void UpdateAddress(UpdateAddressDTO request)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
                var address = _mapper.Map<Address>(request);
                _addressRepo.UpdateAddress(address);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError("Error updating address with request: {@request}, Exception: {ex}", request, ex);
            }
        }

        public void DeleteAddress(AddressDTO request)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
                var address = _mapper.Map<Address>(request);
                _addressRepo.DeleteAddress(address);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError("Error deleting address with request: {@request}, Exception: {ex}", request, ex);
            }
        }
    }
}
