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
        /// <summary>
        /// creates a boardmember in database
        /// </summary>
        /// <param name="boardMember"></param>
        public void CreateBoardMember(BoardMember boardMember)
        {
            try
            {
                _db.AddAsync(boardMember);
                _db.SaveChanges();
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
        public void UpdateBoardMemberParameters(BoardMember boardMember)
        {
            try
            {
                _db.Update(boardMember);
                _db.SaveChanges();
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
        public void DeleteBoardMember(BoardMember boardMember)
        {
            try
            {
                _db.Remove(boardMember);
                _db.SaveChanges();
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in Delete in Boardmember: " + ex.Message);
            }
        }
        /// <summary>
        /// adds a user to a boardmember in database
        /// </summary>
        /// <param name="boardMember"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void AddUserToBoardMember(BoardMember boardMember)
        {
            try
            {
                _db.Update(boardMember);
                _db.SaveChanges();
            }
            catch (SqlException ex)
            {
                _logger.LogError("Error in AddUser in Boardmember: " + ex.Message);
            }
        }
    }
}
