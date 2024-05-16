using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.BoardMember
{
    public class BoardMemberDTO : IEntity
    {
        public string Title { get; set; }
        public UserDTO Member { get; set; }
        public string Description { get; set; }

        public DateOnly StartDate { get; set; }
        public Byte[] Image { get; set; }

        public Guid Id { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
