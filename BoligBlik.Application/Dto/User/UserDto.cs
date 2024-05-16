using BoligBlik.Application.DTO.Adress;
using BoligBlik.Domain.Common.Interfaces;
using BoligBlik.Domain.Value;

namespace BoligBlik.Application.DTO.User
{
    // DTO for User
    public class UserDTO : IEntity
    {
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Role { get; set; }
    }
}
