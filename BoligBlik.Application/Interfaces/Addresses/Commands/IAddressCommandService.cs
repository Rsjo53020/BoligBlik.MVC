using BoligBlik.Application.DTO.Address;

namespace BoligBlik.Application.Interfaces.Addresses.Commands
{
    public interface IAddressCommandService
    {
        void CreateAddress(CreateAddressDTO request);
        void UpdateAddress(AddressDTO request);
        void DeleteAddress(AddressDTO request);
    }
}
