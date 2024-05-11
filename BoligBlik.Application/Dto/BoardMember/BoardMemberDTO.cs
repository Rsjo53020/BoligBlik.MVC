using BoligBlik.Application.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Dto.BoardMember
{
    public class BoardMemberDTO
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public GetUserDto Member { get; set; }
        public string Description { get; set; }

        public DateOnly StartDate { get; set; }
        public Byte[] Image { get; set; }

        public Byte[] RowVersion { get; set; }
    }
}
