using BoligBlik.MVC.DTO.Adress;
using System.ComponentModel.DataAnnotations;

namespace BoligBlik.MVC.DTO.User
{
    // DTO for creating a user
    public class CreateUserDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        public string Role { get; set; }

        public AddressDTO Address { get; set; }
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }

}
