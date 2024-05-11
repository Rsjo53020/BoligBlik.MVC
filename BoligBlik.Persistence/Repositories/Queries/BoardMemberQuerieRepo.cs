using BoligBlik.Application.Interfaces.BoardMember.Queries;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Persistence.Repositories.Queries
{
    public class BoardMemberQuerieRepo : IBoardMemberQuerieRepo
    {
        private readonly BoligBlikContext _db;
        public BoardMemberQuerieRepo(BoligBlikContext db)
        {
            _db = db;
        }
        /// <summary>
        /// reads alle boardmembers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BoardMember> ReadAllBoardMembers()
        {
            return _db.BoardMembers.AsNoTracking();
                
        }
        /// <summary>
        /// returns one boardmember from their title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public BoardMember ReadBoardMember(string title)
        {
            return _db.BoardMembers.AsNoTracking()
                .Where(x => x.Title == title).FirstOrDefault();
        }
    }
}
