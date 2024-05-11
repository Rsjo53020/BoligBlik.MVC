using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.BoardMember.Commands
{
    public interface IBoardMemberCommandRepo
    {
        void AddUserToBoardMember(Domain.Entities.BoardMember boardMember);
        void CreateBoardMember(Domain.Entities.BoardMember boardMember);
        void DeleteBoardMember(Domain.Entities.BoardMember boardMember);
        void UpdateBoardMemberParameters(Domain.Entities.BoardMember boardMember);
    }
}
