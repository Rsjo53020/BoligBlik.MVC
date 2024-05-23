using BoligBlik.MVC.DTO.User;
using BoligBlik.MVC.Models.Common;
using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Models.BoardMembers
{
    public class BoardMemberViewModel : EntityViewModel
    {
        public string Title { get; set; }
        public UserViewModel User { get; set; }
        public string Description { get; set; }
    }
}
