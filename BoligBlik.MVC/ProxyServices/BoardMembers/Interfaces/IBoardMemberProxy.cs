using BoligBlik.MVC.DTO.BoardMember;

namespace BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces
{
    public interface IBoardMemberProxy
    {
        Task<IEnumerable<BoardMemberDTO>> GetAllBoardMembersAsync();
        Task<BoardMemberDTO> GetBoardMemberAsync(Guid id);
        Task<bool> CreateBoardMemberAsync(CreateBoardMemberDTO boardMember);
        Task<bool> UpdateBoardMemberAsync(UpdateBoardMemberDTO boardMember);
        Task<bool> DeleteBoardMemberAsync(Guid id);
    }
}
