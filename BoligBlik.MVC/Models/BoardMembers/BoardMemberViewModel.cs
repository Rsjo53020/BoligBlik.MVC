using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Models.BoardMembers
{
    public class BoardMemberViewModel
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public UserViewModel Member { get; set; }
        public string Description { get; set; }

        public DateOnly StartDate { get; set; }
        public Byte[] Image { get; set; }

        public Byte[] RowVersion { get; set; }
    }
}
