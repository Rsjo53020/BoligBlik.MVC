using BoligBlik.Application.Dto.BoardMember;
using BoligBlik.Domain.Entities;


namespace BoligBlik.Application.Interfaces.BoardMember.Mappers
{
    public interface IDTOToModels
    {
        public Domain.Entities.BoardMember MapCreateBoardMemberToModel(CreateBoardMemberDTO DTO);
        public Domain.Entities.BoardMember MapUpdateBoardMemberToModel(UpdateBoardmemberDTO DTO);
        public Domain.Entities.BoardMember MapDeleteBoardMemberToModel(DeleteBoardMemberDTO DTO);
        public Domain.Entities.BoardMember MapAddUserToBoardMemberToModel(AddUserToBoardMemberDTO DTO);
        public Domain.Entities.BoardMember MapUpdateBoardMemberparametersToModel(UpdateBoardMemberParametersDTO DTO);

    }
}
