using BoligBlik.Application.DTO.BoardMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.BoardMembers.Queries
{
    public interface IBoardMemberQuerieService
    {
        public BoardMemberDTO ReadBoardMember(string title);
        public IEnumerable<BoardMemberDTO> ReadAllBoardMembers();
    }
}
