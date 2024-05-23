using System.ComponentModel.DataAnnotations;
using BoligBlik.MVC.Common.Interfaces;
using BoligBlik.MVC.Models.Common;

namespace BoligBlik.MVC.Models.Users
{
    public class CreateUserViewModel 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
