using BoligBlik.Domain.Value;
using BoligBlik.Entities;

namespace BoligBlik.Application.Interfaces.Infrastructure
{
    public interface IAddressValidationInf
    {
        Task<bool> ValidateAddressAsync(Address address);
    }
}
