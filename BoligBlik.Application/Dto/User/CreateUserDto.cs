using BoligBlik.Application.DTO.Adress;
using System.ComponentModel.DataAnnotations;

namespace BoligBlik.Application.DTO.User
{
    // DTO for creating a user
    public class CreateUserDTO
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string Role { get; set; }

        public AddressDTO Address { get; set; }
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }

}
