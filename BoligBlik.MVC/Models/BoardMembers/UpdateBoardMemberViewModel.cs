using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Models.BoardMembers
{
    public class UpdateBoardMemberViewModel
    {
        public UserViewModel User { get; set; }
        public DateOnly StartDate { get; set; }
        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
        public Guid? CreateBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; }
        public Guid? DeletedBy { get; set; }
    }
}
