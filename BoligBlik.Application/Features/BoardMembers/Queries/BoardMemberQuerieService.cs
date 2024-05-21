using AutoMapper;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.BoardMembers.Queries;
using BoligBlik.Application.Interfaces.Repositories;

namespace BoligBlik.Application.Features.BoardMembers.Queries
{
    public class BoardMemberQuerieService : IBoardMemberQuerieService
    {
        //Repositories
        private readonly IBoardMemberQuerieRepo _boardMemberRepo;
        private readonly IUserQuerieRepo _userQuerieRepo;
        //Mapper
        private IMapper _mapper;
        public BoardMemberQuerieService(IMapper mapper, IBoardMemberQuerieRepo boardMemberQuerieRepo,
            IUserQuerieRepo userQuerieRepo)
        {
            _mapper = mapper;
            _boardMemberRepo = boardMemberQuerieRepo;
            _userQuerieRepo = userQuerieRepo;
        }
        /// <summary>
        /// Reads a single boardmember of title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<BoardMemberDTO> ReadBoardMemberAsync(Guid id)
        {
            var member = await _boardMemberRepo.ReadBoardMemberAsync(id);
            //var user = await _userQuerieRepo.ReadUserAsync(member.UserID);
            //map to DTO
            var memberDTO = _mapper.Map<BoardMemberDTO>(member);

            return memberDTO;
        }
        /// <summary>
        /// reads all boardmembers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BoardMemberDTO>> ReadAllBoardMembersAsync()
        {
            var members = await _boardMemberRepo.ReadAllBoardMembersAsync();
            List<BoardMemberDTO> memberDTOs = new List<BoardMemberDTO>();
            foreach (var member in members)
            {
                //member.User = await _userQuerieRepo.ReadUserAsync(member.UserID);
                //map to DTO
                var boardMemberDTO = _mapper.Map<BoardMemberDTO>(member);
                boardMemberDTO.User = _mapper.Map<UserDTO>(member.User);

                memberDTOs.Add(boardMemberDTO);
            }
            return memberDTOs;
        }
    }
}
