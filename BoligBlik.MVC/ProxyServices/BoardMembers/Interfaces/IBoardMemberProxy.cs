using BoligBlik.MVC.DTO.BoardMember;

namespace BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces
{
    public interface IBoardMemberProxy
    {
        Task<bool> CreateBoardMemberAsync(CreateBoardMemberDTO boardMember);
        Task<IEnumerable<BoardMemberDTO>> GetAllBoardMembersAsync();
        Task<BoardMemberDTO> GetBoardMemberAsync(Guid id);

        Task<bool> UpdateBoardMemberAsync(BoardMemberDTO boardMember);
        Task<bool> DeleteBoardMemberAsync(Guid id, string rowVersion);
    }
}
