using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using BoligBlik.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Persistence.Repositories.BoardMembers
{
    public class BoardMemberQuerieRepo : IBoardMemberQuerieRepo
    {
        private readonly BoligBlikContext _db;
        private readonly ILogger<BoardMember> _logger;
        public BoardMemberQuerieRepo(BoligBlikContext db)
        {
            _db = db;
        }
        /// <summary>
        /// reads alle boardmembers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BoardMember>> ReadAllBoardMembersAsync()
        {
            try
            {
                return await _db.BoardMembers.AsNoTracking().ToListAsync();


            }
            catch (Exception ex)
            {
                _logger.LogError("Error in ReadAll in BoardMember: " + ex.Message);
                return Enumerable.Empty<BoardMember>();

            }
        }
        /// <summary>
        /// returns one boardmember from their title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<BoardMember> ReadBoardMemberAsync(Guid id)
        {
            try
            {
                return await _db.BoardMembers.AsNoTracking()
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Read in Booking: " + ex.Message);
                return null; /*new BoardMember();*/
            }
        }
    }
}
