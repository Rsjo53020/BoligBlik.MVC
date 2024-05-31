using BoligBlik.Domain.Value;
using BoligBlik.Entities;

namespace BoligBlik.Application.Interfaces.Infrastructure
{
    /// <summary>
    /// Interface for AddressValidationInf
    /// </summary>
    public interface IAddressValidationInf
    {
        bool ValidateAddress(Address address);
    }
}
