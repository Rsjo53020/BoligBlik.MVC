using BoligBlik.MVC.DTO.BoardMember;

namespace BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces
{
    public interface IBoardMemberProxy
    {
        Task<IEnumerable<BoardMemberDTO>> GetAllBoardMembersAsync();
        Task<BoardMemberDTO> GetBoardMemberAsync(Guid id);
        Task<bool> CreateBoardMemberAsync(CreateBoardMemberDTO boardMember);
        Task<bool> UpdateBoardMemberAsync(BoardMemberDTO boardMember);
        Task<bool> DeleteBoardMemberAsync(BoardMemberDTO boardMember);
    }
}
