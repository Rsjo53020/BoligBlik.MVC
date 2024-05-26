using BoligBlik.Application.DTO.Address;
using BoligBlik.Entities;

namespace BoligBlik.Application.Interfaces.Addresses.Queries
{
    public interface IAddressQuerieService
    {
        Task<IEnumerable<AddressDTO>> ReadAllAsync();
        Task<AddressDTO> ReadAddress(Guid id);
        Task<AddressDTO> GetUserAddress(Guid userId);
    }
}
