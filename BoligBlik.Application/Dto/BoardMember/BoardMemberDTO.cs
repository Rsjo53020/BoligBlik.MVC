using BoligBlik.Application.Common.Entity;
using BoligBlik.Application.DTO.User;
using BoligBlik.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BoligBlik.Application.DTO.BoardMember
{
    public class BoardMemberDTO : EntityDTO
    {
        [StringLength(50)]
        public string Title { get; set; }
        public UserDTO User { get; set; }
        public string Description { get; set; }
    }
}
