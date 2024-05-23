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
            CreateMap<CreateBoardMemberDTO, BoardMember>().ReverseMap();

            //BoardMemberDTO
            CreateMap<BoardMemberDTO, BoardMember>().ReverseMap();
        }
    }
}
