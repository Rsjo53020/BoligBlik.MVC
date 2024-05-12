using System.Data;
using BoligBlik.Application.DTO.User;
using BoligBlik.Application.Features.BoardMembers.Commands;
using BoligBlik.Application.Interfaces.Repositories;
using BoligBlik.Application.Interfaces.Users.Commands;
using BoligBlik.Application.Interfaces.Users.Mappers;
using Microsoft.Extensions.Logging;

namespace BoligBlik.Application.Features.User.Commands
{
    public class UserCommandService : IUserCommandService
    {
        // Dependencies
        private readonly IUnitOfWork _uow;
        private readonly IUserDTOMapper _mapper;
        private readonly IUserCommandRepo _userRepo;
        private readonly ILogger<BoardMemberCommandService> _logger;

        // Constructor 
        public UserCommandService(IUnitOfWork uow, IUserDTOMapper userDTOMapper, IUserCommandRepo userCommandRepo)
        {
            _uow = uow;
            _mapper = userDTOMapper;
            _userRepo = userCommandRepo;
        }

        // this method creates a user using Unit of Work pattern
        public async Task<bool> CreateUserAsync(CreateUserDTO request)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);

                    var user = _mapper.MapCreateUserToModel(request);
                    await _userRepo.CreateUserAsync(user);
                    await _uow.CommitChangesAsync();
                    return true; 
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error creating user with request: {@request}, Exception: {ex}", request, ex);
                return false; 
            }
        }

        // this method Deletes a user using Unit of Work pattern
        public async Task DeleteUserAsync(DeleteUserDTO request)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);
                var user = _mapper.MapDeleteUserToModel(request);
                await _userRepo.DeleteUserAsync(user);
                await _uow.CommitChangesAsync();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error deleting user with request: {@request}, Exception: {ex}", request, ex);
            }
        }

        // this method updates a user using Unit of Work pattern
        public async Task UpdateUserAsync(UpdateUserDTO request)
        {
            try
            {
                _uow.BeginTransaction(IsolationLevel.Serializable);
                var user = _mapper.MapUpdateUserToModel(request);
                await _userRepo.UpdateUserAsync(user);
                await _uow.CommitChangesAsync();
            }
            catch (Exception ex)
            {
                _uow.Rollback();
                _logger.LogError("Error updating user with request: {@request}, Exception: {ex}", request, ex);
            }
        }
    }
}
