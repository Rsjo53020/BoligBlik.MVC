using AutoMapper;
using BoligBlik.Application.Interfaces.Addresses.Commands;
using BoligBlik.Application.Interfaces.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.Data;
using BoligBlik.Application.DTO.Address;
using BoligBlik.Entities;
using BoligBlik.Domain.Entities;
using Microsoft.Extensions.Logging;
using BoligBlik.Application.Interfaces.Repositories.Addresses.Command;
using BoligBlik.Application.Interfaces.Repositories.UnitOfWork;

namespace BoligBlik.Application.Features.Addresses.Commands
{
    public class AddressCommandService : IAddressCommandService
    {
        //Dependencies
        private readonly IAddressCommandRepo _addressRepo;
        private readonly IAddressValidationInf _addressValidationInf;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<IAddressCommandService> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="addressRepo"></param>
        /// <param name="mapper"></param>
        /// <param name="addressValidationInf"></param>
        /// <param name="unitOfWork"></param>
        /// <param name="logger"></param>
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

                var resultat = _addressValidationInf.ValidateAddress(address);
               
                    _addressRepo.CreateAddress(address);
                    _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError("Error create address with request. Exception:", ex.Message);
                throw new ValidationException("Validation failed on address");
            }
        }

        /// <summary>
        /// Update Address
        /// </summary>
        /// <param name="request"></param>
        /// <exception cref="ValidationException"></exception>
        public void UpdateAddress(AddressDTO request)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);
                var address = _mapper.Map<Address>(request);
                var result = _addressValidationInf.ValidateAddress(address);
                if (result)
                {
                    _addressRepo.UpdateAddress(address);
                    _unitOfWork.Commit();
                }
                else
                {
                    throw new ValidationException();
                }
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                _logger.LogError("Error updating address with request. Exception:", ex.Message);
            }
        }

        /// <summary>
        /// Delete Address
        /// </summary>
        /// <param name="request"></param>
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
                _logger.LogError("Error deleting address with request. Exception:", ex.Message);
            }
        }
    }
}
