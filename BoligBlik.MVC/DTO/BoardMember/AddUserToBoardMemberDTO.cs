using BoligBlik.MVC.DTO.User;

namespace BoligBlik.MVC.DTO.BoardMember
{
    public class AddUserToBoardMemberDTO
    {
        public Guid ID { get; set; }
        public UserDTO User { get; set; }
        public DateOnly StartDate { get; set; }

        public byte[] RowVersion { get; set; }

    }
}
