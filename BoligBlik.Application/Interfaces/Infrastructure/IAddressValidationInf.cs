using BoligBlik.Domain.Value;

namespace BoligBlik.Application.Interfaces.Infrastructure
{
    public interface IAddressValidationInf
    {
        Task<bool> ValidateAddressAsync(Address address);
       
    }
}
