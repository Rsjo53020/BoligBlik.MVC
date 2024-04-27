using System.ComponentModel.DataAnnotations;

namespace BoligBlik.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string FormerRole { get; set; }
        public string Role { get; set; }
    }
}