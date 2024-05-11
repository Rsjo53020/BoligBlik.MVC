using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.BoardMember.Queries
{
    public interface IBoardMemberQuerieRepo
    {
        IEnumerable<Domain.Entities.BoardMember> ReadAllBoardMembers();
        Domain.Entities.BoardMember ReadBoardMember(string title);
    }
}
