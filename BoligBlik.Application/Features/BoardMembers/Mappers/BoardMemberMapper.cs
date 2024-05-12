using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.Interfaces.BoardMembers.Mappers;
using BoligBlik.Application.Interfaces.Users.Mappers;

namespace BoligBlik.Application.Features.BoardMembers.Mappers
{
    public class BoardMemberMapper : IBoardMemberMapper
    {
        //mapper
        private readonly IUserMapper _userToDTOMapper;
        public BoardMemberMapper(IUserMapper userToDTOMapper)
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
                Member = _userToDTOMapper.MapModelToUserDTO(boardMember.Member),
                Description = boardMember.Description,
                StartDate = boardMember.StartDate,
                Image = boardMember.Image,
                RowVersion = boardMember.RowVersion,
            };
            return boardMemberDTO;
        }
    }
}
