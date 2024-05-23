using BoligBlik.MVC.DTO.Common;

namespace BoligBlik.MVC.DTO.User
{
    public class UserDTO : EntityDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }
    }
}
