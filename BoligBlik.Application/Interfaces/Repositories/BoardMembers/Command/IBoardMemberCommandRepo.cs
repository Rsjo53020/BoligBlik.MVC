using BoligBlik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.Repositories.BoardMembers.Command
{
    public interface IBoardMemberCommandRepo
    {
        void CreateBoardMember(BoardMember boardMember);
        void DeleteBoardMember(Guid id, byte[] rowVersion);
        void UpdateBoardMember(BoardMember boardMember);
    }
}
