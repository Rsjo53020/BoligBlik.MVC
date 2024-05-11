using BoligBlik.Application.Dto.BoardMember;
using BoligBlik.Application.Interfaces.BoardMember.Mappers;

namespace BoligBlik.Application.Features.BoardMember.Mappers
{
    public class BoardMemberMapper : IBoardMemberMapper
    {
        //mapper
        private readonly IUserToDTOMapper _userToDTOMapper;
        public BoardMemberMapper(IUserToDTOMapper userToDTOMapper)
        {
            _userToDTOMapper = userToDTOMapper;
        }
        /// <summary>
        /// Maps BoardMember to DTO
        /// </summary>
        /// <param name="boardMember"></param>
        /// <returns></returns>
        public BoardMemberDTO MapModelToBoardMemberDTO(Domain.Entities.BoardMember boardMember)
        {
            var boardMemberDTO = new BoardMemberDTO
            {
                ID = boardMember.Id,
                Title = boardMember.Title,
                Member = _userToDTOMapper.UserToDTO(boardMember.Member),
                Description = boardMember.Description,
                StartDate = boardMember.StartDate,
                Image = boardMember.Image,
                RowVersion = boardMember.RowVersion,
            };
            return boardMemberDTO;
        }
    }
}
