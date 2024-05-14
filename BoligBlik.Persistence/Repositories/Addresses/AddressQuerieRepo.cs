using BoligBlik.Application.DTO.Adress;
using BoligBlik.Application.Interfaces.Repositories;

namespace BoligBlik.Persistence.Repositories.Addresses
{
    public class AddressQuerieRepo : IAddressQuerieRepo
    {
        public Task<IEnumerable<AddressDTO>> ReadAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
