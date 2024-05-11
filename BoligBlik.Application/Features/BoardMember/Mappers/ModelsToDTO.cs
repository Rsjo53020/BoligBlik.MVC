using BoligBlik.Application.Dto.BoardMember;
using BoligBlik.Application.Interfaces.BoardMember.Mappers;

namespace BoligBlik.Application.Features.BoardMember.Mappers
{
    public class ModelsToDTO : IModelsToDTO
    {
        public BoardMemberDTO MapModelToBoardMemberDTO(Domain.Entities.BoardMember boardMember)
        {
            var boardMemberDTO = new BoardMemberDTO
            {
                ID = BoardMember.BoardMemberID,
                Title = boardMember.Title,
                Member = ,
                Description = boardMember.Description,
                StartDate = boardMember.StartDate,
                Image = boardMember.Image,
                RowVersion = boardMember.RowVersion,
            }
        }
    }
}
