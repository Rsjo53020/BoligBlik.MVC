using BoligBlik.MVC.DTO.BoardMember;

namespace BoligBlik.MVC.ProxyServices.BoardMembers.Interfaces
{
    public interface IBoardMemberServices
    {
        Task<IEnumerable<BoardMemberDTO>> GetAllBoardMembers();
        Task<BoardMemberDTO> GetBoardMember(string title);
        Task<bool> CreateBoardMember(CreateBoardMemberDTO boardMember);
        Task<bool> UpdateBoardMember(UpdateBoardMemberDTO boardMember);
        Task<bool> DeleteBoardMember(Guid id);
    }
}
