using BoligBlik.Application.DTO.BoardMember;

namespace BoligBlik.Application.Interfaces.BoardMembers.Queries
{
    public interface IBoardMemberQuerieService
    {
        public Task<BoardMemberDTO> ReadBoardMemberAsync(string title);
        public Task<IEnumerable<BoardMemberDTO>> ReadAllBoardMembersAsync();
    }
}
