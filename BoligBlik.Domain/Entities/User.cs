using BoligBlik.Domain.Value;
using System.ComponentModel.DataAnnotations;
using BoligBlik.Domain.Common.Shared;

namespace BoligBlik.Domain.Entities
{
    public class User : Entity
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
        public string FormerRole { get; set; }
        public string Role { get; set; }
        public Address Address { get; set; }

        // constructor for creating a new user
        internal User() : base()
        {
            
        }
        public User (Guid id, string email, string firstname, string lastname,
            string phonenumber, Address address, string formerRole, string role)
        {
            Id = id;
            EmailAddress = email;
            FirstName = firstname;
            LastName = lastname;
            PhoneNumber = phonenumber;
            Address = address;
            FormerRole = formerRole;
            Role = role;
        }
    }
}