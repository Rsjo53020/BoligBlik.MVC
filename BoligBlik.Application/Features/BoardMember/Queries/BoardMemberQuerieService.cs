using BoligBlik.Application.Dto.BoardMember;
using BoligBlik.Application.Interfaces.BoardMember.Mappers;
using BoligBlik.Application.Interfaces.BoardMember.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoligBlik.Application.Features.BoardMember.Queries
{
    public class BoardMemberQuerieService : IBoardMemberQuerieService
    {
        //Repositories
        private readonly IBoardMemberQuerieRepo _boardMemberRepo;
        //Mapper
        private readonly IBoardMemberMapper _mapper;
        public BoardMemberQuerieService(IBoardMemberMapper boardMemberDTOMapper,
            IBoardMemberQuerieRepo boardMemberQuerieRepo)
        {
            _mapper = boardMemberDTOMapper;
            _boardMemberRepo = boardMemberQuerieRepo;
        }
        /// <summary>
        /// Reads a single boardmember of title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public BoardMemberDTO ReadBoardMember(string title)
        {
            var member = _boardMemberRepo.ReadBoardMember(title);
            //map to DTO
            var memberDTO = _mapper.MapModelToBoardMemberDTO(member);
            return memberDTO;
        }
        /// <summary>
        /// reads all boardmembers
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BoardMemberDTO> ReadAllBoardMembers()
        {
            var members = _boardMemberRepo.ReadAllBoardMembers();
            List<BoardMemberDTO> memberDTOs = new List<BoardMemberDTO>();
            foreach (var member in members)
            {
                //map to DTO
                memberDTOs.Add(_mapper.MapModelToBoardMemberDTO(member));
            }
            return memberDTOs;
        }
    }
}
