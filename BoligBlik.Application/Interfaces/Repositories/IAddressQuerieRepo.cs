using BoligBlik.Entities;

namespace BoligBlik.Application.Interfaces.Repositories
{
    public interface IAddressQuerieRepo
    {
        Task<IEnumerable<Address>> ReadAllAsync();
        Task<Address> ReadAddress(Address address);
    }
}
