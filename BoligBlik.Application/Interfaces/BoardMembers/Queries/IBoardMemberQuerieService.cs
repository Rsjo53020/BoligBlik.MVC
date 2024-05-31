using BoligBlik.Application.DTO.BoardMember;

namespace BoligBlik.Application.Interfaces.BoardMembers.Queries
{
    /// <summary>
    /// Interface for BoardMemberQuerieService
    /// </summary>
    public interface IBoardMemberQuerieService
    {
        Task<BoardMemberDTO> ReadBoardMemberAsync(Guid id);
        Task<IEnumerable<BoardMemberDTO>> ReadAllBoardMembersAsync();
    }
}
