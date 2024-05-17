namespace BoligBlik.MVC.Models.BoardMembers
{
    public class CreateBoardMemberViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid? CreateBy { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
