using BoligBlik.Application.DTO.BoardMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.BoardMembers.Commands
{
    /// <summary>
    /// Interface for BoardMemberCommandService
    /// </summary>
    public interface IBoardMemberCommandService
    {
        void CreateBoardMember(CreateBoardMemberDTO request);
        void UpdateBoardMember(BoardMemberDTO request);
        public void DeleteBoardMember(Guid id, Byte[] rowVersion);
    }
}
