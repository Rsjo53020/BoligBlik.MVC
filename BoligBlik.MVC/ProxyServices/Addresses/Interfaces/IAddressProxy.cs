using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BoardMember;

namespace BoligBlik.MVC.ProxyServices.Addresses.Interfaces
{
    public interface IAddressProxy
    {
        Task<IEnumerable<AddressDTO>> GetAllAddressAsync();
        Task<bool> CreateAddressAsync(CreateAddressDTO createAddressDTO);
        Task<bool> UpdateAddressAsync(UpdateAddressDTO updateAddressDTO);
        Task<bool> DeleteAddressAsync(Guid id);

    }
}