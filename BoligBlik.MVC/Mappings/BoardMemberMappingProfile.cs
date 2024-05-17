using AutoMapper;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.Models.BoardMembers;

namespace BoligBlik.MVC.Mappings
{
    public class BoardMemberMappingProfile : Profile
    {
        public BoardMemberMappingProfile()
        {
            CreateMap<CreateBoardMemberDTO, CreateBoardMemberViewModel>();
            CreateMap<CreateBoardMemberViewModel, CreateBoardMemberDTO>();

            CreateMap<BoardMemberDTO, BoardMemberViewModel>();
            CreateMap<BoardMemberViewModel, BoardMemberDTO>();

            CreateMap<UpdateBoardMemberDTO, UpdateBoardMemberViewModel>();
            CreateMap<UpdateBoardMemberViewModel, UpdateBoardMemberDTO>();

            CreateMap<DeleteBoardMemberDTO, DeleteBoardMemberViewModel>();
            CreateMap<DeleteBoardMemberViewModel, DeleteBoardMemberDTO>();
        }
    }
}
