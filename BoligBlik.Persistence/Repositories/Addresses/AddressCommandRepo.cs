using BoligBlik.Application.Interfaces.Repositories.Addresses.Command;
using BoligBlik.Application.Interfaces.Repositories.UnitOfWork;
using BoligBlik.Domain.Entities;
using BoligBlik.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.Addresses
{
    public class AddressCommandRepo : IAddressCommandRepo
    {
        //Dependencies
        private readonly BoligBlikContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddressCommandRepo> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="logger"></param>
        /// <param name="unitOfWork"></param>
        public AddressCommandRepo(BoligBlikContext dbContext, 
            ILogger<AddressCommandRepo> logger, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Create Address
        /// </summary>
        /// <param name="address"></param>
        public void CreateAddress(Address address)
        {
            try
            {
                if (!AddressExists(address))
                    _dbContext.AddAsync(address);
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in create in address: " + ex.Message);
            }

        }

        /// <summary>
        /// Update Address and Concurrency check
        /// </summary>
        /// <param name="address"></param>
        public void UpdateAddress(Address address)
        {
            try
            {
                // Concurrency Check by RowVersion by Original and Parameter value
                _dbContext.Update(address).Property(b => b.RowVersion).OriginalValue = address.RowVersion;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in updateAddress: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete Adress
        /// </summary>
        /// <param name="address"></param>
        public void DeleteAddress(Address address)
        {
            try
            {
                _dbContext.Remove(address);
                _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in deleteAddress", ex.Message);
            }
        }

        /// <summary>
        /// Check if address exist
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private bool AddressExists(Address address)
        {
            var result = _dbContext.Adresses.Any(x => x.DoorNumber == address.DoorNumber
            && x.HouseNumber == address.HouseNumber
            && x.Floor == address.Floor
            && x.Street == address.Street
            && x.PostalCode.PostalcodeNumber == address.PostalCode.PostalcodeNumber
            && x.PostalCode.City == address.PostalCode.City);
            return result;
        }
    }
}
