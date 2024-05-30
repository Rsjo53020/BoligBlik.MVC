using BoligBlik.Application.Common.Entity;
using BoligBlik.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BoligBlik.Application.DTO.User
{
    public class UserDTO : EntityDTO
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
