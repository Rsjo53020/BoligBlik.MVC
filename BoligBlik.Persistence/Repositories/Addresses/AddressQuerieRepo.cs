using AutoMapper;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.Addresses
{
    public class AddressQuerieRepo : IAddressQuerieRepo
    {
        private readonly BoligBlikContext _dbContext;
        private readonly ILogger<Address> _logger;

        public AddressQuerieRepo(BoligBlikContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Address>> ReadAllAsync()
        {
            try
            {
                 var addresses =  await _dbContext.Adresses.AsNoTracking().ToListAsync();
                 return addresses;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ReadAll addresses: " + ex.Message);
                return Enumerable.Empty<Address>();
            }
        }

        

        public async Task<Address> ReadAddress(Guid id)
        {
            try
            {
                return await _dbContext.Adresses.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ReadAddress in AddressRepository " + ex.Message);
                throw new ApplicationException("Error in ReadAddress in AddressRepository", ex);
            }
        }
    }
}
