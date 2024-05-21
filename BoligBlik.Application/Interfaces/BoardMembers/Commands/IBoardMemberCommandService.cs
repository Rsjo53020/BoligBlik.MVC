using BoligBlik.Application.DTO.BoardMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Interfaces.BoardMembers.Commands
{
    public interface IBoardMemberCommandService
    {
        public void CreateBoardMember(CreateBoardMemberDTO request);
        public void UpdateBoardMember(UpdateBoardMemberDTO request);
        public void DeleteBoardMember(Guid id);
    }
}
