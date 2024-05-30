using System.ComponentModel.DataAnnotations;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.User
{
    public class CreateUserDTO
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(75)]
        public string EmailAddress { get; set; }
    }
}
