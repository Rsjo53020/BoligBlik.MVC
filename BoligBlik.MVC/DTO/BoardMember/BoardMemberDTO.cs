using BoligBlik.MVC.DTO.Common;
using BoligBlik.MVC.DTO.User;

namespace BoligBlik.MVC.DTO.BoardMember
{
    public class BoardMemberDTO : EntityDTO
    {
        public string Title { get; set; }
        public UserDTO User { get; set; }
        public string Description { get; set; }
    }
}
