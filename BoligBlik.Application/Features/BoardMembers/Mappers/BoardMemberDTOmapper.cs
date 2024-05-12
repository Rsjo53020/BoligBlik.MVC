using BoligBlik.Application.Dto.BoardMember;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.Interfaces.BoardMembers.Mappers;
using BoligBlik.Application.Interfaces.Users.Mappers;
using BoligBlik.Domain.Entities;

namespace BoligBlik.Application.Features.BoardMembers.Mappers
{
    public class BoardMemberDTOmapper : IBoardMemberDTOMapper
    {
        private readonly IUserDTOMapper _mapper;
        public BoardMemberDTOmapper(IUserDTOMapper mapper)
        {
            _mapper = mapper;
        }
        /// <summary>
        /// maps dto to model
        /// </summary>
        /// <param name="DTO"></param>
        /// <returns></returns>
        public BoardMember MapAddUserToBoardMemberToModel(AddUserToBoardMemberDTO DTO)
        {
            var boardMember = new BoardMember()
            {
                Id = DTO.ID,
                Member = _mapper.MapUserToModel(DTO.User),
                StartDate = DTO.StartDate,
                RowVersion = DTO.RowVersion,
            };
            return boardMember;
        }
        /// <summary>
        /// map CreateBoardMemberDTO to BoardMember
        /// </summary>
        /// <param name="DTO"></param>
        /// <returns></returns>
        public BoardMember MapCreateBoardMemberToModel(CreateBoardMemberDTO DTO)
        {
            BoardMember boardMember = new()
            {
                Title = DTO.Title,
                Description = DTO.Description,
            };
            return boardMember;
        }
        /// <summary>
        /// maps delete dto to model
        /// </summary>
        /// <param name="DTO"></param>
        /// <returns></returns>
        public BoardMember MapDeleteBoardMemberToModel(DeleteBoardMemberDTO DTO)
        {
            var boardMember = new BoardMember()
            {
                Id = DTO.ID,
                RowVersion = DTO.RowVersion,
            };
            return boardMember;
        }
        /// <summary>
        /// map dto to model
        /// </summary>
        /// <param name="DTO"></param>
        /// <returns></returns>
        public BoardMember MapUpdateBoardMemberparametersToModel(UpdateBoardMemberParametersDTO DTO)
        {
            var boardMember = new BoardMember()
            {
                Id = DTO.ID,
                Title = DTO.Title,
                Description = DTO.Description,
                RowVersion = DTO.RowVersion,
            };
            return boardMember;
        }
        /// <summary>
        /// map dto to model
        /// </summary>
        /// <param name="DTO"></param>
        /// <returns></returns>
        public BoardMember MapUpdateBoardMemberToModel(UpdateBoardmemberDTO DTO)
        {
            var boardMember = new BoardMember()
            {
                Id = DTO.ID,
                Member = _mapper.MapUserToModel(DTO.User),
                StartDate = DTO.StartDate,
                RowVersion = DTO.RowVersion,
            };
            return boardMember;
        }
    }
}
