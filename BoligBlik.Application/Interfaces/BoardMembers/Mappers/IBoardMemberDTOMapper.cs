using BoligBlik.Application.Dto.BoardMember;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Domain.Entities;


namespace BoligBlik.Application.Interfaces.BoardMembers.Mappers
{
    public interface IBoardMemberDTOMapper
    {
        public BoardMember MapCreateBoardMemberToModel(CreateBoardMemberDTO DTO);
        public BoardMember MapUpdateBoardMemberToModel(UpdateBoardmemberDTO DTO);
        public BoardMember MapDeleteBoardMemberToModel(DeleteBoardMemberDTO DTO);
        public BoardMember MapAddUserToBoardMemberToModel(AddUserToBoardMemberDTO DTO);
        public BoardMember MapUpdateBoardMemberparametersToModel(UpdateBoardMemberParametersDTO DTO);

    }
}
