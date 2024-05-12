using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.Interfaces.BoardMembers.Mappers;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Features.BoardMembers.Mappers
{
    public class BoardMemberDTOmapper : IBoardMemberDTOMapper
    {
        public BoardMember MapAddUserToBoardMemberToModel(AddUserToBoardMemberDTO DTO)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// map CreateBoardMemberDTO to BoardMember
        /// </summary>
        /// <param name="DTO"></param>
        /// <returns></returns>
        public BoardMember MapCreateBoardMemberToModel(CreateBoardMemberDTO DTO)
        {
            BoardMember user = new()
            {
                Title = DTO.Title,
                Description = DTO.Description,
            };
            return user;
        }

        public BoardMember MapDeleteBoardMemberToModel(DeleteBoardMemberDTO DTO)
        {
            throw new NotImplementedException();
        }

        public BoardMember MapUpdateBoardMemberparametersToModel(UpdateBoardMemberParametersDTO DTO)
        {
            throw new NotImplementedException();
        }

        public BoardMember MapUpdateBoardMemberToModel(UpdateBoardmemberDTO DTO)
        {
            throw new NotImplementedException();
        }
    }
}
