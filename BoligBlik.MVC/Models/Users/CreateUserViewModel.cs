using System.ComponentModel.DataAnnotations;

namespace BoligBlik.MVC.Models.Users
{
    public class CreateUserViewModel
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
