using BoligBlik.Application.Dto.BoardMember;
using BoligBlik.Application.Interfaces.BoardMember.Mappers;

namespace BoligBlik.Application.Features.BoardMember.Mappers
{
    public class BoardMemberDTOmapper : IBoardMemberDTOMapper
    {
        public Domain.Entities.BoardMember MapAddUserToBoardMemberToModel(AddUserToBoardMemberDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.BoardMember MapCreateBoardMemberToModel(CreateBoardMemberDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.BoardMember MapDeleteBoardMemberToModel(DeleteBoardMemberDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.BoardMember MapUpdateBoardMemberparametersToModel(UpdateBoardMemberParametersDTO DTO)
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.BoardMember MapUpdateBoardMemberToModel(UpdateBoardmemberDTO DTO)
        {
            throw new NotImplementedException();
        }
    }
}
