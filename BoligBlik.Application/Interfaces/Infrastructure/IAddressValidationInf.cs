using BoligBlik.Domain.Value;
using BoligBlik.Entities;

namespace BoligBlik.Application.Interfaces.Infrastructure
{
    public interface IAddressValidationInf
    {
        bool ValidateAddress(Address address);
    }
}
