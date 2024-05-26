using BoligBlik.Entities;

namespace BoligBlik.Application.Interfaces.Repositories
{
    public interface IAddressQuerieRepo
    {
        Task<IEnumerable<Address>> ReadAllAsync();
        Task<Address> ReadAddress(Guid id);
        Task<Address> GetUserAdress(Guid userId);
    }
}
