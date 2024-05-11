using BoligBlik.Application.Interfaces.BoardMember.Commands;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Persistence.Repositories.Commands
{
    public class BoardMemberCommandRepo : IBoardMemberCommandRepo
    {
        private readonly BoligBlikContext _db;
        public BoardMemberCommandRepo(BoligBlikContext db)
        {
            _db = db;
        }

        public void CreateBoardMember(BoardMember boardMember)
        {
            throw new NotImplementedException();
        }



        public void UpdateBoardMemberParameters(BoardMember boardMember)
        {
            throw new NotImplementedException();
        }
        public void DeleteBoardMember(BoardMember boardMember)
        {
            throw new NotImplementedException();
        }
        public void AddUserToBoardMember(BoardMember boardMember)
        {
            throw new NotImplementedException();
        }
    }
}
