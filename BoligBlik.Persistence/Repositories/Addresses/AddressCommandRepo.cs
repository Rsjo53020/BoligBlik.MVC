﻿using System.Data;
using BoligBlik.Application.Interfaces.Repositories;
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
        private readonly BoligBlikContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<Booking> _logger;

        public AddressCommandRepo(BoligBlikContext dbContext, ILogger<Booking> logger, IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

        public void CreateAddress(Address address)
        {


            try
            {
                _dbContext.AddAsync(address);
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in create in address: " + ex.Message);
            }

        }

        public void UpdateAddress(Address address)
        {
            try
            {
                _dbContext.Adresses.Include(a => a.Users)
                    .Include(a => a.Bookings)
                    .FirstOrDefaultAsync(m => m.Id == address.Id);

                _dbContext.Update(address).Property(b => b.RowVersion).OriginalValue = address.RowVersion;
                /*_dbContext.SaveChangesAsync();*/

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in updateAddress: {ex.Message}");
            }
        }

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
    }
}
