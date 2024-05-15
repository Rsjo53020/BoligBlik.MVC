using AutoMapper;
using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.Addresses
{
    public class AddressQuerieRepo : IAddressQuerieRepo
    {
        private readonly BoligBlikContext _dbContext;
        private readonly ILogger<User> _logger;
        private readonly IMapper _mapper;

        public AddressQuerieRepo(BoligBlikContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AddressDTO>> ReadAllAsync()
        {
            throw new NotImplementedException();
            //try
            //{

            //    var address = await _dbContext.Users.AsNoTracking().Where(u => u.Address != null).ToListAsync();
            //    var mapAdressList = _mapper.Map<User>(address).Address;

            //    return mapAdressList;

            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError("Error in ReadAll addresses: " + ex.Message);
            //    return Enumerable.Empty<AddressDTO>();
            //}
        }
    }
}
