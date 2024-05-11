using BoligBlik.Application.Dto.BoardMember;
using BoligBlik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.BoardMembers.Mappers
{
    public interface IBoardMemberMapper
    {
        public BoardMemberDTO MapModelToBoardMemberDTO(BoardMember boardMember);
    }
}
