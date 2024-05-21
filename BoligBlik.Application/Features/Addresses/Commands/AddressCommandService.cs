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
        private readonly IAddressCommandRepo _addressRepo;
        private readonly IAddressValidationInf _addressValidationInf;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<IAddressCommandService> _logger;
        public AddressCommandService(IAddressCommandRepo addressRepo, IMapper mapper, IAddressValidationInf addressValidationInf, IUnitOfWork unitOfWork, ILogger<IAddressCommandService> logger)
        {
            _addressRepo = addressRepo;
            _addressValidationInf = addressValidationInf;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }


        public void CreateAddress(CreateAddressDTO request)
        {
            try
            {
                _unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                var address = _mapper.Map<Address>(request);

                var resultat = _addressValidationInf.ValidateAddressAsync(address);
                if (resultat != null)
                {
                    _addressRepo.CreateAddress(address);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error create address with request: {@request}, Exception: {ex}", request, ex);
                _unitOfWork.Rollback();
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

        public void DeleteAddress(DeleteAddressDTO request)
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
