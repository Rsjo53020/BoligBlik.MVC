using System.ComponentModel.DataAnnotations;

namespace BoligBlik.MVC.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Password don't march.")]
        public string? ComfirmPassword { get; set; }

        public string? Address { get; set; }

        
    }
}
