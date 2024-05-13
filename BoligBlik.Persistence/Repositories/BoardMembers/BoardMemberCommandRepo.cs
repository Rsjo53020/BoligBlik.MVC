using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Persistence.Repositories.BoardMembers
{
    public class BoardMemberCommandRepo : IBoardMemberCommandRepo
    {
        private readonly BoligBlikContext _db;
        private readonly ILogger<BoardMemberCommandRepo> _logger;
        public BoardMemberCommandRepo(BoligBlikContext db)
        {
            _db = db;
        }

        public void CreateBoardMember(BoardMember boardMember)
        {
            try
            {
                _db.AddAsync(boardMember);
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in CreateAsync in Boardmember: " + ex.Message);
            }
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
