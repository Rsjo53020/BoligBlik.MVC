using BoligBlik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.Repositories
{
    public interface IBoardMemberQuerieRepo
    {
        Task<BoardMember> ReadBoardMemberAsync(Guid id);
        Task<IEnumerable<BoardMember>> ReadAllBoardMembersAsync();

    }
}
