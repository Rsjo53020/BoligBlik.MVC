using BoligBlik.MVC.DTO.Address;
using BoligBlik.MVC.DTO.BoardMember;

namespace BoligBlik.MVC.ProxyServices.Addresses.Interfaces
{
    public interface IAddressProxy
    {
        Task<IEnumerable<AddressDTO>> GetAllAddressAsync();
        Task<AddressDTO> GetAddressAsync(Guid id);
        Task<bool> CreateAddressAsync(CreateAddressDTO createAddressDTO);
        Task<bool> UpdateAddressAsync(AddressDTO addressDTO);

        Task<bool> DeleteAddressAsync(AddressDTO response);
       
    }
}