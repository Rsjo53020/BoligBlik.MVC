using AutoMapper;
using BoligBlik.Application.DTO.BoardMember;
using BoligBlik.Application.Interfaces.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Data;

namespace BoligBlik.Application.Features.BoardMembers.Commands
{
    public class BoardMemberCommandService : IBoardMemberCommandService
    {
        
        
        //UnitOfWork
        private readonly IUnitOfWork _uow;
        //Mappers
        private readonly IMapper _mapper;
        //Repositories
        private readonly IBoardMemberCommandRepo _boardMemberRepo;
        //Logger
        private readonly ILogger<BoardMemberCommandService> _logger;
        public BoardMemberCommandService(IUnitOfWork uow, IMapper mapper, 
             IBoardMemberCommandRepo boardMemberCommandRepo)
        {
            _uow = uow;   
            _mapper = mapper;
            _boardMemberRepo = boardMemberCommandRepo;
        }

        /// <summary>
        /// Create a boardMember as a role
        /// </summary>
        /// <param name="request"></param>
        public void CreateBoardMember(CreateBoardMemberDTO request)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);
                //map to model
                var boardMember = _mapper.Map<BoardMember>(request);

                _boardMemberRepo.CreateBoardMember(boardMember);

                _uow.Commit();
                
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("could not create BoardMember", ex);
            }
        }
        /// <summary>
        /// Update Boardmember
        /// </summary>
        /// <param name="request"></param>
        public void UpdateBoardMember(BoardMemberDTO request)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);
                //map to model
                var boardMember = _mapper.Map<BoardMember>(request);
                boardMember.User = _mapper.Map<User>(request.User);


                _boardMemberRepo.UpdateBoardMember(boardMember);

                _uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("could not update BoardMember", ex);
            }
        }
        /// <summary>
        /// delete BoardMember
        /// </summary>
        /// <param name="request"></param>
        public void DeleteBoardMember(BoardMemberDTO request)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);

                _boardMemberRepo.DeleteBoardMember(request.Id);

                _uow.Commit();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("could not delete BoardMember", ex);
            }
        }
    }
}
