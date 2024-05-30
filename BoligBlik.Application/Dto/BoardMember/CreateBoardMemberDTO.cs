using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoligBlik.Application.Common.Entity;
using BoligBlik.Domain.Common.Interfaces;

namespace BoligBlik.Application.DTO.BoardMember
{
    public class CreateBoardMemberDTO 
    {
        [StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
