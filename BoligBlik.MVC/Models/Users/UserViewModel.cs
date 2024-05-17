using BoligBlik.MVC.Models.Addresses;

namespace BoligBlik.MVC.Models.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public string Role { get; set; }

        public string FormerRole { get; set; }

        public AddressViewModel Address { get; set; }
    }
}
