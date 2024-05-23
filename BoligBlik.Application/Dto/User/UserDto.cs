using BoligBlik.Application.Common.Entity;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.User
{
    public class UserDTO : EntityDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
