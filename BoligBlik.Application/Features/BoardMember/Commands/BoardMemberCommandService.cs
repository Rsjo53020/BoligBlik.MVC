using BoligBlik.Application.Dto.BoardMember;
using BoligBlik.Application.Interfaces.BoardMember.Commands;
using BoligBlik.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Features.BoardMember.Commands
{
    public class BoardMemberCommandService : IBoardMemberCommandService
    {
        //UnitOfWork
        private readonly IUnitOfWork _uow;
        public BoardMemberCommandService(IUnitOfWork uow)
        {
            _uow = uow;   
        }
        public void AddUserToBoardMember(AddUserToBoardMemberDTO request)
        {
            throw new NotImplementedException();
        }

        public void CreateBoardMember(CreateBoardMemberDTO request)
        {
            throw new NotImplementedException();
        }

        public void DeleteBoardMember(DeleteBoardMemberDTO request)
        {
            throw new NotImplementedException();
        }

        public void UpdateBoardMember(UpdateBoardmemberDTO request)
        {
            throw new NotImplementedException();
        }

        public void UpdateBoardmemberPatameters(UpdateBoardMemberParametersDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
