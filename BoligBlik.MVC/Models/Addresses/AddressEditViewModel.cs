using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Models.Addresses
{
    public class AddressEditViewModel
    {
        public AddressViewModel Address { get; set; }
        public IEnumerable<UserViewModel> UsersWithoutAddress { get; set; }
        public UserViewModel selectedUser { get; set; }
    }
}
