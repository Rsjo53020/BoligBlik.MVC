using System.Security.Cryptography.X509Certificates;
using BoligBlik.Application.Interfaces.Repositories;
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
                var addresses = await _dbContext.Adresses.AsNoTracking()
                    .Include(a => a.Users)
                    .Include(a => a.Bookings)
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
                var response = await _dbContext.Adresses.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
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
        public async Task<Address> GetUserAdress(Guid userId)
        {
            try
            {
                var address = await _dbContext.Adresses
                    .AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Users.Any(u => u.Id == userId));

                return address;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetAddress in AddressRepository: " + ex.Message);

                throw;
            }
        }
    }
}
