using BoligBlik.Application.Dto.BoardMember;
using BoligBlik.Application.Interfaces.BoardMember.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Features.BoardMember.Queries
{
    public class BoardMemberQuerieService : IBoardMemberQuerieService
    {
        public BoardMemberQuerieService()
        {
            
        }
        public IEnumerable<BoardMemberDTO> ReadAllBoardMembers()
        {
            throw new NotImplementedException();
        }

        public BoardMemberDTO ReadBoardMember(string title)
        {
            throw new NotImplementedException();
        }
    }
}
