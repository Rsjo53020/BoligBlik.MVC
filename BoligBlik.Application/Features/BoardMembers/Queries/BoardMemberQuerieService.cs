using AutoMapper;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.Interfaces.BoardMembers.Queries;
using BoligBlik.Application.Interfaces.Repositories;

namespace BoligBlik.Application.Features.BoardMembers.Queries
{
    public class BoardMemberQuerieService : IBoardMemberQuerieService
    {
        //Repositories
        private readonly IBoardMemberQuerieRepo _boardMemberRepo;
        //Mapper
        private readonly IMapper _mapper;
        public BoardMemberQuerieService(IMapper mapper,
            IBoardMemberQuerieRepo boardMemberQuerieRepo)
        {
            _mapper = mapper;
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
            var memberDTO = _mapper.Map<BoardMemberDTO>(member);
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
                memberDTOs.Add(_mapper.Map<BoardMemberDTO>(member));
            }
            return memberDTOs;
        }
    }
}
