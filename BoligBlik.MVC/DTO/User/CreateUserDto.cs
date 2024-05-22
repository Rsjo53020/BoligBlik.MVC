using System.ComponentModel.DataAnnotations;
using BoligBlik.MVC.DTO.Interfaces;

namespace BoligBlik.MVC.DTO.User
{
    // DTO for creating a user
    public class CreateUserDTO 
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

    }
}
