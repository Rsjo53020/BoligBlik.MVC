using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.BoardMembers.Queries
{
    public interface IBoardMemberQuerieRepo
    {
        Domain.Entities.BoardMember ReadBoardMember(string title);
        IEnumerable<Domain.Entities.BoardMember> ReadAllBoardMembers();
        
    }
}
