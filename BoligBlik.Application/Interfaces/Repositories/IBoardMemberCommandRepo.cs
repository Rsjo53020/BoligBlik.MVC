using BoligBlik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.Repositories
{
    public interface IBoardMemberCommandRepo
    {
        void CreateBoardMember(BoardMember boardMember);
        void DeleteBoardMember(Guid id);
        void UpdateBoardMember(BoardMember boardMember);
    }
}
