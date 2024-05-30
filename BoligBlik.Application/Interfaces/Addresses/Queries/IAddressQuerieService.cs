using BoligBlik.Application.DTO.Address;
using BoligBlik.Entities;

namespace BoligBlik.Application.Interfaces.Addresses.Queries
{
    /// <summary>
    /// Interface for AddressQuerieService
    /// </summary>
    public interface IAddressQuerieService
    {
        Task<IEnumerable<AddressDTO>> ReadAllAsync();
        Task<AddressDTO> ReadAddressAsync(Guid id);
    }
}
