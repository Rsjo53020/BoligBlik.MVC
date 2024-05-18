using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.Addresses
{
    public class AddressCommandRepo : IAddressCommandRepo
    {
        private readonly BoligBlikContext _dbContext;
        private readonly ILogger<Booking> _logger;

        public AddressCommandRepo(BoligBlikContext dbContext, ILogger<Booking> logger)
        {
            _dbContext = dbContext;
        }

        public void CreateAddress(Address address)
        {
            try
            {
                _dbContext.AddAsync(address);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in CreateAddress", ex.Message);
            }
        }

        public void UpdateAddress(Address address)
        {
            try
            {
                _dbContext.AddAsync(address);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in CreateAddress", ex.Message);
            }
        }

        public void DeleteAddress(Address address)
        {
            try
            {
                _dbContext.AddAsync(address);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in CreateAddress", ex.Message);
            }
        }
    }
}
