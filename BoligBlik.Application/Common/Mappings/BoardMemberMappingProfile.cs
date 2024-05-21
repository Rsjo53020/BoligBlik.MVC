using AutoMapper;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BoligBlik.Application.Common.Mappings
{
    public class BoardMemberMappingProfile : Profile
    {
        /// <summary>
        /// Creates Mapping profiles on BoardMemberProfile, using AutoMapper
        /// </summary>
        public BoardMemberMappingProfile()
        {
            //CreateBoardMemberDTO
            CreateMap<CreateBoardMemberDTO, BoardMember>();
            CreateMap<BoardMember, CreateBoardMemberDTO>();

            //BoardMemberDTO
            CreateMap<BoardMemberDTO, BoardMember>().ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));
            CreateMap<BoardMember, BoardMemberDTO>().ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            //UpdateBoardMemberDTO
            CreateMap<DeleteBoardMemberDTO, BoardMember>();
            CreateMap<BoardMember, DeleteBoardMemberDTO>();

            //DeleteBoardMemberDTO
            CreateMap<DeleteBoardMemberDTO, BoardMember>();
            CreateMap<BoardMember, DeleteBoardMemberDTO>();

            //AddUserToBoardMemberDTO
            CreateMap<AddUserToBoardMemberDTO, BoardMember>();
            CreateMap<BoardMember, AddUserToBoardMemberDTO>();

            //UpdateBoardMemberParameters
            CreateMap<UpdateBoardMemberParametersDTO, BoardMember>();
            CreateMap<BoardMember, UpdateBoardMemberParametersDTO>();
        }

    }
}
