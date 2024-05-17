using BoligBlik.MVC.DTO.Interfaces;

namespace BoligBlik.MVC.DTO.BoardMember
{
    public class CreateBoardMemberDTO : IEntity, IBaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
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
