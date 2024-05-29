using AutoMapper;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Interfaces.BoardMembers.Queries;
using BoligBlik.Application.Interfaces.Repositories;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Application.Features.BoardMembers.Queries
{
    public class BoardMemberQuerieService : IBoardMemberQuerieService
    {
        //Repositories
        private readonly IBoardMemberQuerieRepo _boardMemberRepo;
        private readonly IUserQuerieRepo _userQuerieRepo;
        //Mapper
        private IMapper _mapper;
        //Logger
        private readonly ILogger<BoardMemberQuerieService> _logger;
        public BoardMemberQuerieService(IMapper mapper, IBoardMemberQuerieRepo boardMemberQuerieRepo,
            IUserQuerieRepo userQuerieRepo, ILogger<BoardMemberQuerieService> logger)
        {
            _mapper = mapper;
            _boardMemberRepo = boardMemberQuerieRepo;
            _userQuerieRepo = userQuerieRepo;
            _logger = logger;
        }
        /// <summary>
        /// Reads a single boardmember of title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<BoardMemberDTO> ReadBoardMemberAsync(Guid id)
        {
            try
            {
                var member = await _boardMemberRepo.ReadBoardMemberAsync(id);
                //map to DTO
                var memberDTO = _mapper.Map<BoardMemberDTO>(member);
                memberDTO.User = _mapper.Map<UserDTO>(member.User);

                return memberDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError("something went wrong when reading a boardmember");
                return null;
            }
        }
        /// <summary>
        /// reads all boardmembers
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<BoardMemberDTO>> ReadAllBoardMembersAsync()
        {
            try
            {
                var members = await _boardMemberRepo.ReadAllBoardMembersAsync();
                List<BoardMemberDTO> memberDTOs = new List<BoardMemberDTO>();
                foreach (var member in members)
                {
                    //map to DTO
                    var boardMemberDTO = _mapper.Map<BoardMemberDTO>(member);
                    boardMemberDTO.User = _mapper.Map<UserDTO>(member.User);

                    memberDTOs.Add(boardMemberDTO);
                }
                return memberDTOs;
            }
            catch (Exception ex)
            {
                _logger.LogError("something went wrong when reading all boardmembers");
                return null;
            }
        }
    }
}
