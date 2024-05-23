using BoligBlik.MVC.Models.Addresses;
using BoligBlik.MVC.Models.Common;

namespace BoligBlik.MVC.Models.Users
{
    public class UserViewModel : EntityViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
