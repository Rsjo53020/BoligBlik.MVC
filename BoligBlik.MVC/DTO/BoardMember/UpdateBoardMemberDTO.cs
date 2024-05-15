using BoligBlik.MVC.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.MVC.DTO.BoardMember
{
    public class UpdateBoardMemberDTO
    {
        public Guid ID { get; set; }
        public UserDTO User { get; set; }
        public DateOnly StartDate { get; set; }
        public Byte[] RowVersion { get; set; }
    }
}
