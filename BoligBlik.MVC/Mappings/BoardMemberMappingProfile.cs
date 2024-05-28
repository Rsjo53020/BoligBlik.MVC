using AutoMapper;
using BoligBlik.MVC.DTO.BoardMember;
using BoligBlik.MVC.Models.BoardMembers;
using BoligBlik.MVC.Models.Users;

namespace BoligBlik.MVC.Mappings
{
    public class BoardMemberMappingProfile : Profile
    {
        public BoardMemberMappingProfile()
        {
            CreateMap<CreateBoardMemberDTO, CreateBoardMemberViewModel>().ReverseMap();

            CreateMap<BoardMemberDTO, BoardMemberViewModel>().ReverseMap();
        }
    }
}
