using BoligBlik.Application.DTO.Address;

namespace BoligBlik.Application.Interfaces.Addresses.Commands
{
    /// <summary>
    /// Interface for AddressCommandService
    /// </summary>
    public interface IAddressCommandService
    {
        void CreateAddress(CreateAddressDTO request);
        void UpdateAddress(UpdateAddressDTO request);
        void DeleteAddress(AddressDTO request);
    }
}
