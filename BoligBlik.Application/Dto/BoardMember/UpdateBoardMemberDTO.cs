using BoligBlik.Application.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Dto.BoardMember
{
    public class UpdateBoardmemberDTO
    {
        public Guid ID { get; set; }
        public GetUserDto User { get; set; }
        public DateOnly StartDate { get; set; }
        public Byte[] RowVersion { get; set; }
    }
}
