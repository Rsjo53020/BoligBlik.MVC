using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

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
        /// <summary>
        /// creates a boardmember in database
        /// </summary>
        /// <param name="boardMember"></param>
        public void CreateBoardMember(BoardMember boardMember)
        {
            try
            {
                _db.AddAsync(boardMember);
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in Create in Boardmember: " + ex.Message);
            }
        }
        /// <summary>
        /// updates a boardmember in database
        /// </summary>
        /// <param name="boardMember"></param>
        public void UpdateBoardMember(BoardMember boardMember)
        {
            try
            {
                //handle concurrency
                _db.Update(boardMember).Property(b => b.RowVersion).OriginalValue = boardMember.RowVersion;
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in Update in Boardmember: " + ex.Message);
            }
        }
        /// <summary>
        /// deletes a boardmember in database
        /// </summary>
        /// <param name="boardMember"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteBoardMember(Guid id, Byte[] rowVersion)
        {
            try
            {
                //handle concurrency
                _db.Remove(_db.BoardMembers.Where(b => b.Id == id).FirstOrDefault())
                    .Property(b => b.RowVersion).OriginalValue = rowVersion;
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in Delete in Boardmember: " + ex.Message);
            }
        }
    }
}
