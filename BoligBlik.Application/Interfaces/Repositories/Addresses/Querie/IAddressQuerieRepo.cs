using BoligBlik.Entities;

namespace BoligBlik.Application.Interfaces.Repositories.Addresses.Querie
{
    public interface IAddressQuerieRepo
    {
        Task<IEnumerable<Address>> ReadAllAsync();
        Task<Address> ReadAddress(Guid id);
    }
}
