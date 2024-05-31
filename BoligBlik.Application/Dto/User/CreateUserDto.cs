using System.ComponentModel.DataAnnotations;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.User
{
    public class CreateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
