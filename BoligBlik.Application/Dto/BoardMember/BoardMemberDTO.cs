using BoligBlik.Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.DTO.BoardMember
{
    public class BoardMemberDTO
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public GetUserDTO Member { get; set; }
        public string Description { get; set; }

        public DateOnly StartDate { get; set; }
        public Byte[] Image { get; set; }

        public Byte[] RowVersion { get; set; }
    }
}
