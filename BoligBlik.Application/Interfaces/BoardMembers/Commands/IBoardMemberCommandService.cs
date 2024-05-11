using BoligBlik.Application.Dto.BoardMember;
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
        public void UpdateBoardMember(UpdateBoardmemberDTO request);
        public void UpdateBoardMemberPatameters(UpdateBoardMemberParametersDTO request);
        public void DeleteBoardMember(DeleteBoardMemberDTO request);
        public void AddUserToBoardMember(AddUserToBoardMemberDTO request);
    }
}
