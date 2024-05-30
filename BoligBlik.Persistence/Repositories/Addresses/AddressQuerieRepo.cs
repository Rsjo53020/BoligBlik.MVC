using System.Security.Cryptography.X509Certificates;
using BoligBlik.Application.Interfaces.Repositories.Addresses.Querie;
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
                var addresses = await _dbContext.Adresses
                    .AsNoTracking()
                    .Include(a => a.Users)
                    .Include(a => a.Bookings)
                    .ThenInclude(i => i.Item)
                    .ToListAsync();
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
                var response = await _dbContext.Adresses.AsNoTracking()
                    .Include(a => a.Users)
                    .Include(a => a.Bookings)
                    .ThenInclude(i => i.Item)
                    .FirstOrDefaultAsync(b => b.Id == id);
                if (response == null)
                {
                    new Exception("der findes ingen address med et id");
                }


                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ReadAddress in AddressRepository " + ex.Message);
                throw new ApplicationException("Error in ReadAddress in AddressRepository", ex);
            }
        }
    }
}
