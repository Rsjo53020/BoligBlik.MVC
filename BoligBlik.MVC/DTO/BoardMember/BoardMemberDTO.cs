using BoligBlik.MVC.DTO.Interfaces;
using BoligBlik.MVC.DTO.User;

namespace BoligBlik.MVC.DTO.BoardMember
{
    public class BoardMemberDTO : IEntity
    {
        public string Title { get; set; }
        public UserDTO User { get; set; }
        public string Description { get; set; }

        public DateOnly StartDate { get; set; }
        public byte[] Image { get; set; }

        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
