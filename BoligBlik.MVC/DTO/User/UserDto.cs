using BoligBlik.MVC.DTO.Adress;

namespace BoligBlik.MVC.DTO.User
{
    // DTO for User
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Role { get; set; }

        public string FormerRole { get; set; }

        public AddressDTO Address { get; set; }
    }
}
