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
        /// <summary>
        /// map CreateBoardMemberDTO to BoardMember
        /// </summary>
        /// <param name="DTO"></param>
        /// <returns></returns>
        public Domain.Entities.BoardMember MapCreateBoardMemberToModel(CreateBoardMemberDTO DTO)
        {
            Domain.Entities.BoardMember user = new()
            {
                Title = DTO.Title,
                Description = DTO.Description,
            };
            return user;
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
