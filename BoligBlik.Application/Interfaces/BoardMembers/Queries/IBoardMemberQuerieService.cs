using BoligBlik.Application.DTO.BoardMember;

namespace BoligBlik.Application.Interfaces.BoardMembers.Queries
{
    public interface IBoardMemberQuerieService
    {
        public BoardMemberDTO ReadBoardMember(string title);
        public IEnumerable<BoardMemberDTO> ReadAllBoardMembers();
    }
}
