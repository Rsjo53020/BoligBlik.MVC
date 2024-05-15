using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.MVC.DTO.BoardMember
{
    public class UpdateBoardMemberParametersDTO
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Byte[] RowVersion { get; set; }
    }
}
