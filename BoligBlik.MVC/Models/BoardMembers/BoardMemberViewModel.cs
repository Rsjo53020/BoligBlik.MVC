using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Models.BoardMembers
{
    public class BoardMemberViewModel
    {
        public string Title { get; set; }
        public UserViewModel User { get; set; }
        public string Description { get; set; }

        public DateOnly StartDate { get; set; }
        public byte[] Image { get; set; }

        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
