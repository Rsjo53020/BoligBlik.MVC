using BoligBlik.Application.Common.Entity;
using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.BoardMember
{
    public class BoardMemberDTO : EntityDTO
    {
        public string Title { get; set; }
        public UserDTO User { get; set; }
        public string Description { get; set; }
    }
}
