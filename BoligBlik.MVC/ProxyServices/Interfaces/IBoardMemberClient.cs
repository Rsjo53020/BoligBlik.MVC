using BoligBlik.MVC.DTO.BoardMember;

namespace BoligBlik.MVC.ProxyServices.Interfaces
{
    public interface IBoardMemberClient
    {
        Task<List<BoardMemberDTO>> GetBoardMembers();
        Task<BoardMemberDTO> GetBoardMember(int id);
        Task<BoardMemberDTO> CreateBoardMember(BoardMemberDTO boardMember);
    }
}
