using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Models.BoardMembers
{
    public class UpdateBoardMemberViewModel
    {
        public Guid ID { get; set; }
        public UserViewModel User { get; set; }
        public DateOnly StartDate { get; set; }
        public Byte[] RowVersion { get; set; }
    }
}
