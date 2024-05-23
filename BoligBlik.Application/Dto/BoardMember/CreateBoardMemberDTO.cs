using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Common.Entity;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.BoardMember
{
    public class CreateBoardMemberDTO 
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
