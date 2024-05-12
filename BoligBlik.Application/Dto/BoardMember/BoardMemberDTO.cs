using BoligBlik.Application.Dto.User;

namespace BoligBlik.Application.Dto.BoardMember
{
    public class BoardMemberDTO
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public UserDto Member { get; set; }
        public string Description { get; set; }

        public DateOnly StartDate { get; set; }
        public Byte[] Image { get; set; }

        public Byte[] RowVersion { get; set; }
    }
}
